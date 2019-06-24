using Lithnet.Laps.DirectoryInterfaces;

namespace KuLeuven.GBiomed.Laps.Services
{
    public sealed class DirectoryComputerService: IComputerService
    {
        private readonly IDirectory directory;

        public DirectoryComputerService(IDirectory directory)
        {
            this.directory = directory;
        }

        public IComputer GetComputer(string computerName)
        {
            return directory.GetComputer(computerName);
        }
    }
}
