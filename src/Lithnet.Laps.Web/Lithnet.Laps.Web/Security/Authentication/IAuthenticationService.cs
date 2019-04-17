using Lithnet.Laps.DirectoryInterfaces;

namespace Lithnet.Laps.Web.Security.Authentication
{
    public interface IAuthenticationService
    {
        IUser GetLoggedInUser();
    }
}
