using System;
using Lithnet.Laps.DirectoryInterfaces;

namespace KuLeuven.GBiomed.Laps.Services
{
    public interface IPasswordService
    {
        Password GetPassword(IComputer computer);
        void SetPasswordExpiryTime(IComputer computer, DateTime newDateTime);
    }
}
