using Lithnet.Laps.Web.Models;
using Lithnet.Laps.Web.Security.Authorization.ConfigurationFile;
using Lithnet.Laps.Web.Security.Authorization.Sql;

namespace Lithnet.Laps.Web.Security.Authorization.Combined
{
    /// <summary>
    /// Authorization service that checks both config file and SQL database.
    ///
    /// If one of the both authorization services grants access to the user, the user is authorized.
    /// </summary>
    public class SqlOrConfigurationFileAuthorizationService: IAuthorizationService
    {
        private readonly SqlAuthorizationService sqlAuthorizationService;
        private readonly ConfigurationFileAuthorizationService configurationFileAuthorizationService;
        
        public SqlOrConfigurationFileAuthorizationService(
            SqlAuthorizationService sqlAuthorizationService,
            ConfigurationFileAuthorizationService configurationFileAuthorizationService)
        {
            this.sqlAuthorizationService = sqlAuthorizationService;
            this.configurationFileAuthorizationService = configurationFileAuthorizationService;
        }
        
        public AuthorizationResponse CanAccessPassword(IUser user, IComputer computer, ITarget target)
        {
            var responseViaConfigFile = configurationFileAuthorizationService.CanAccessPassword(
                user,
                computer,
                target
            );

            return responseViaConfigFile.IsAuthorized ? responseViaConfigFile : sqlAuthorizationService.CanAccessPassword(user, computer, target);
        }
    }
}