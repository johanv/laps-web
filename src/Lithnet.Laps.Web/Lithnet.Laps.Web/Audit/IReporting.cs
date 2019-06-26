﻿using System;
using KuLeuven.GBiomed.Laps.Audit;
using KuLeuven.GBiomed.Laps.Security.Authorization;
using Lithnet.Laps.DirectoryInterfaces;
using Lithnet.Laps.Web.Models;

namespace Lithnet.Laps.Web.Audit
{
    public interface IReporting
    {
        void LogSuccessEvent(int eventID, string logMessage);
        void LogErrorEvent(int eventID, string logMessage, Exception ex);
        void PerformAuditSuccessActions(LapRequestModel model, ITarget target, AuthorizationResponse authorizationResponse, IUser user, IComputer computer, Password password);
        void PerformAuditFailureActions(LapRequestModel model, string userMessage, int eventID, string logMessage, Exception ex, ITarget target, AuthorizationResponse authorizationResponse, IUser user, IComputer computer);
    }
}
