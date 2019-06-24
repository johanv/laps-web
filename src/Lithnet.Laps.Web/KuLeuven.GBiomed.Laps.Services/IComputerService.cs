using Lithnet.Laps.DirectoryInterfaces;

namespace KuLeuven.GBiomed.Laps.Services
{
    public interface IComputerService
    {
        IComputer GetComputer(string computerName);
    }
}
