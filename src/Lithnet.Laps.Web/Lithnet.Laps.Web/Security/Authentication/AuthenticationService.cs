using System.DirectoryServices.AccountManagement;
using System.Web;
using Lithnet.Laps.Web.App_LocalResources;
using Lithnet.Laps.Web.Models;

namespace Lithnet.Laps.Web.Security.Authentication
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IDirectory directory;

        public AuthenticationService(IDirectory directory)
        {
            this.directory = directory;
        }

        public IUser GetLoggedInUser()
        {
            var httpContext = HttpContext.Current;

            if (httpContext?.User == null)
            {
                return (IUser) null;
            }

            var httpUser = httpContext.User;
            var directoryUser = directory.GetUser(httpUser.Identity.Name);

            if (directoryUser == null)
            {
                throw new NoMatchingPrincipalException(string.Format(LogMessages.UserNotFoundInDirectory, httpContext.User.Identity.Name));
            }

            return directoryUser;
        }
    }
}