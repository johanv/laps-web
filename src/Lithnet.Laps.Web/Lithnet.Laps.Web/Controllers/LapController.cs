﻿using System;
using System.ComponentModel;
using System.Web.Mvc;
using KuLeuven.GBiomed.Laps.Audit;
using KuLeuven.GBiomed.Laps.Services;
using KuLeuven.GBiomed.Laps.Security.Authentication;
using KuLeuven.GBiomed.Laps.Security.Authorization;
using Lithnet.Laps.ActiveDirectory;
using Lithnet.Laps.DirectoryInterfaces;
using Lithnet.Laps.Web.App_LocalResources;
using Lithnet.Laps.Web.Audit;
using Lithnet.Laps.Web.Models;
using NLog;

namespace Lithnet.Laps.Web.Controllers
{
    [Authorize]
    [Localizable(true)]
    public class LapController : Controller
    {
        private readonly IAuthorizationService authorizationService;
        private readonly ILogger logger;
        private readonly IReporting reporting;
        private readonly IRateLimiter rateLimiter;
        private readonly IAvailableTargets availableTargets;
        private readonly IAuthenticationService authenticationService;
        private readonly IComputerService computerService;
        private readonly IPasswordService passwordService;

        public LapController(IAuthorizationService authorizationService, ILogger logger, IReporting reporting,
            IRateLimiter rateLimiter, IAvailableTargets availableTargets, IAuthenticationService authenticationService,
            IComputerService computerService, IPasswordService passwordService)
        {
            this.authorizationService = authorizationService;
            this.logger = logger;
            this.reporting = reporting;
            this.rateLimiter = rateLimiter;
            this.availableTargets = availableTargets;
            this.authenticationService = authenticationService;
            this.computerService = computerService;
            this.passwordService = passwordService;
        }

        public ActionResult Get()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Get(LapRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            IUser user = null;

            try
            {
                model.FailureReason = null;

                try
                {
                    user = authenticationService.GetLoggedInUser();

                    if (user == null)
                    {
                        throw new UserNotRecognizedException();
                    }
                }
                catch (UserNotRecognizedException ex)
                {
                    return this.LogAndReturnErrorResponse(model, UIMessages.SsoIdentityNotFound, EventIDs.SsoIdentityNotFound, null, ex);
                }

                if (rateLimiter.IsRateLimitExceeded(model, user, this.Request))
                {
                    return this.View("RateLimitExceeded");
                }

                reporting.LogSuccessEvent(EventIDs.UserRequestedPassword, string.Format(LogMessages.UserHasRequestedPassword, user.SamAccountName, model.ComputerName));

                var computer = computerService.GetComputer(model.ComputerName);

                if (computer == null)
                {
                    return this.LogAndReturnErrorResponse(model, UIMessages.ComputerNotFoundInDirectory, EventIDs.ComputerNotFound, string.Format(LogMessages.ComputerNotFoundInDirectory, user.SamAccountName, model.ComputerName));
                }

                // Is a target configured?

                var target = availableTargets.GetMatchingTargetOrNull(computer);

                if (target == null)
                {
                    return this.AuditAndReturnErrorResponse(
                    model: model,
                    userMessage: UIMessages.NotAuthorized,
                    eventID: EventIDs.AuthZFailedNoTargetMatch,
                    logMessage: string.Format(LogMessages.NoTargetsExist, user.SamAccountName,
                        model.ComputerName),
                    user: user,
                    computer: computer
                    );
                }

                // Do authorization check first.

                var authResponse = authorizationService.CanAccessPassword(user, computer, target);

                if (!authResponse.IsAuthorized)
                {
                    return getViewForFailedAuthorization(model, user, computer, authResponse, target);
                }

                // Do actual work only if authorized.

                var password = passwordService.GetPassword(computer);

                if (password == null)
                {
                    return this.LogAndReturnErrorResponse(model, UIMessages.NoLapsPassword, EventIDs.LapsPasswordNotPresent, string.Format(LogMessages.NoLapsPassword, computer.SamAccountName, user.SamAccountName));
                }

                if (!String.IsNullOrEmpty(target.ExpireAfter))
                {
                    try
                    {
                        UpdateTargetPasswordExpiry(target, computer);
                        // Get the password again with the updated expiracy date.
                        password = passwordService.GetPassword(computer);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        return this.LogAndReturnErrorResponse(
                            model,
                            UIMessages.NotAuthorizedToUpdateExpiracy,
                            EventIDs.NotAuthorizedToUpdateExpiracy,
                            string.Format(LogMessages.NotAuthorizedToUpdateExpiracy, computer.SamAccountName, user.SamAccountName)
                        );
                    }
                }

                reporting.PerformAuditSuccessActions(model, target, authResponse, user, computer, password);

                return this.View("Show", new LapEntryModel(computer, password));

            }
            catch (Exception ex)
            {
                return this.LogAndReturnErrorResponse(model, UIMessages.UnexpectedError, EventIDs.UnexpectedError, string.Format(LogMessages.UnhandledError, model.ComputerName, user?.SamAccountName ?? LogMessages.UnknownComputerPlaceholder), ex);
            }
        }

        private ViewResult getViewForFailedAuthorization(LapRequestModel model, IUser user, IComputer computer,
            AuthorizationResponse authResponse, ITarget target)
        {
            ViewResult viewResult;

            viewResult = this.AuditAndReturnErrorResponse(
                model: model,
                userMessage: UIMessages.NotAuthorized,
                eventID: EventIDs.AuthorizationFailed,
                logMessage: string.Format(LogMessages.AuthorizationFailed, user.SamAccountName,
                    model.ComputerName),
                user: user,
                computer: computer,
                target: target);

            // Handle specific result codes of the ConfigurationFileAuthorizationService.
            // FIXME: This dependency on ConfigurationFileAuthorizationService is dodgy.

            if (authResponse.ResultCode == EventIDs.AuthZFailedNoReaderPrincipalMatch)
            {
                viewResult = this.AuditAndReturnErrorResponse(
                    model: model,
                    userMessage: UIMessages.NotAuthorized,
                    eventID: EventIDs.AuthZFailedNoReaderPrincipalMatch,
                    logMessage: string.Format(LogMessages.AuthZFailedNoReaderPrincipalMatch,
                        user.SamAccountName, model.ComputerName),
                    target: target,
                    user: user,
                    computer: computer);
            }

            return viewResult;
        }

        private ViewResult AuditAndReturnErrorResponse(LapRequestModel model, string userMessage, int eventID, string logMessage = null, Exception ex = null, ITarget target = null, AuthorizationResponse authorizationResponse = null, IUser user = null, IComputer computer = null)
        {
            reporting.PerformAuditFailureActions(model, userMessage, eventID, logMessage, ex, target, authorizationResponse, user, computer);
            model.FailureReason = userMessage;
            return this.View("Get", model);
        }

        private ViewResult LogAndReturnErrorResponse(LapRequestModel model, string userMessage, int eventID, string logMessage = null, Exception ex = null)
        {
            reporting.LogErrorEvent(eventID, logMessage ?? userMessage, ex);
            model.FailureReason = userMessage;
            return this.View("Get", model);
        }

        [Localizable(false)]
        private void UpdateTargetPasswordExpiry(ITarget target, IComputer computer)
        {
            TimeSpan t = TimeSpan.Parse(target.ExpireAfter);
            logger.Trace($"Target rule requires password to change after {t}");
            DateTime newDateTime = DateTime.UtcNow.Add(t);
            passwordService.SetPasswordExpiryTime(computer, newDateTime);
            logger.Trace($"Set expiry time for {computer.SamAccountName} to {newDateTime.ToLocalTime()}");
        }
    }
}