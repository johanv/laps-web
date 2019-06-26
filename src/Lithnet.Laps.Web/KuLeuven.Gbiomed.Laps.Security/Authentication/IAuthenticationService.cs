using Lithnet.Laps.DirectoryInterfaces;

namespace KuLeuven.GBiomed.Laps.Security.Authentication
{
    public interface IAuthenticationService
    {
        IUser GetLoggedInUser();
    }
}
