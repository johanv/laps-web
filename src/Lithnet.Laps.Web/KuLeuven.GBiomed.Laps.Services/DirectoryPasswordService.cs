using System;
using Lithnet.Laps.DirectoryInterfaces;

namespace KuLeuven.GBiomed.Laps.Services
{
    public sealed class DirectoryPasswordService: IPasswordService
    {
        private readonly IDirectory directory;

        public DirectoryPasswordService(IDirectory directory)
        {
            this.directory = directory;
        }

        public Password GetPassword(IComputer computer)
        {
            return this.directory.GetPassword(computer);
        }

        public void SetPasswordExpiryTime(IComputer computer, DateTime newDateTime)
        {
            this.directory.SetPasswordExpiryTime(computer, newDateTime);
        }
    }
}
