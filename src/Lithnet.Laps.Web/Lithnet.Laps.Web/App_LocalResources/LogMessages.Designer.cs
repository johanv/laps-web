﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lithnet.Laps.Web.App_LocalResources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LogMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LogMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Lithnet.Laps.Web.App_LocalResources.LogMessages", typeof(LogMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LAP access denied for {user.SamAccountName} to {computer.SamAccountName}.
        /// </summary>
        internal static string AuditEmailSubjectFailure {
            get {
                return ResourceManager.GetString("AuditEmailSubjectFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LAP for {computer.SamAccountName} accessed by {user.SamAccountName}.
        /// </summary>
        internal static string AuditEmailSubjectSuccess {
            get {
                return ResourceManager.GetString("AuditEmailSubjectSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successfully authenticated and mapped directory user
        ///{0}.
        /// </summary>
        internal static string AuthenticatedAndMappedUser {
            get {
                return ResourceManager.GetString("AuthenticatedAndMappedUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The authentication provider returned an error.
        /// </summary>
        internal static string AuthNProviderError {
            get {
                return ResourceManager.GetString("AuthNProviderError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user {0} is not authorized to access the computer {1}..
        /// </summary>
        internal static string AuthorizationFailed {
            get {
                return ResourceManager.GetString("AuthorizationFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error occurred during the authorization code flow.
        /// </summary>
        internal static string AuthZCodeFlowError {
            get {
                return ResourceManager.GetString("AuthZCodeFlowError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user {0} requested access to computer {1} but does not match any of the reader principals that are allowed access to this computer.
        /// </summary>
        internal static string AuthZFailedNoReaderPrincipalMatch {
            get {
                return ResourceManager.GetString("AuthZFailedNoReaderPrincipalMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No user claim was found with the type {0}.
        /// </summary>
        internal static string ClaimNotFound {
            get {
                return ResourceManager.GetString("ClaimNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user {0} requested the password for computer {1} which was not found in the directory.
        /// </summary>
        internal static string ComputerNotFoundInDirectory {
            get {
                return ResourceManager.GetString("ComputerNotFoundInDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to AUDIT: FAILURE          
        ///Username:			{user.SamAccountName}
        ///Name:				{user.DisplayName}
        ///UPN:				{user.UserPrincipalName}
        ///SID:				{user.Sid}
        ///User DN:				{user.DistinguishedName}
        ///Computer Name:			{computer.SamAccountName}
        ///Computer DN:			{computer.DistinguishedName}
        ///Target ID:			{target.ID}
        ///Reader principal:			{reader.Principal}
        ///Detail:				{message}.
        /// </summary>
        internal static string DefaultAuditFailureText {
            get {
                return ResourceManager.GetString("DefaultAuditFailureText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to AUDIT: SUCCESS       
        ///Username:			{user.SamAccountName}
        ///Name:				{user.DisplayName}
        ///UPN:				{user.UserPrincipalName}
        ///SID:				{user.Sid}
        ///User DN:				{user.DistinguishedName}
        ///Computer Name:			{computer.SamAccountName}
        ///Computer DN:			{computer.DistinguishedName}
        ///Target ID:			{target.ID}
        ///Reader principal:			{reader.Principal}.
        /// </summary>
        internal static string DefaultAuditSuccessText {
            get {
                return ResourceManager.GetString("DefaultAuditSuccessText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The computer {0} requested by {1} did not have a LAPS password in the directory.
        /// </summary>
        internal static string NoLapsPassword {
            get {
                return ResourceManager.GetString("NoLapsPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user {0} requested access to computer {1} but no targets exist for this computer.
        /// </summary>
        internal static string NoTargetsExist {
            get {
                return ResourceManager.GetString("NoTargetsExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not update the password expiracy date for computer {1}, as requested by user {0}..
        /// </summary>
        internal static string NotAuthorizedToUpdateExpiracy {
            get {
                return ResourceManager.GetString("NotAuthorizedToUpdateExpiracy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user {0} on IP {1} has exceeded the maximum allowed number of requests per IP ({2} per {3} seconds).
        /// </summary>
        internal static string RateLimitExceededIP {
            get {
                return ResourceManager.GetString("RateLimitExceededIP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The user {0} on IP {1} has exceeded the maximum allowed number of requests per user ({2} per {3} seconds).
        /// </summary>
        internal static string RateLimitExceededUser {
            get {
                return ResourceManager.GetString("RateLimitExceededUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Target rule requires password to change after {0}.
        /// </summary>
        internal static string TargetRuleRequiresPasswordChange {
            get {
                return ResourceManager.GetString("TargetRuleRequiresPasswordChange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unhandled error occurred while processing the request for the password for {0} by user {1}.
        /// </summary>
        internal static string UnhandledError {
            get {
                return ResourceManager.GetString("UnhandledError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to unknown.
        /// </summary>
        internal static string UnknownComputerPlaceholder {
            get {
                return ResourceManager.GetString("UnknownComputerPlaceholder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} has requested the password for {1}.
        /// </summary>
        internal static string UserHasRequestedPassword {
            get {
                return ResourceManager.GetString("UserHasRequestedPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The request could not be processed because the authenticated user was not found in the directory. Claim information:
        ///{0}.
        /// </summary>
        internal static string UserNotFoundInDirectory {
            get {
                return ResourceManager.GetString("UserNotFoundInDirectory", resourceCulture);
            }
        }
    }
}
