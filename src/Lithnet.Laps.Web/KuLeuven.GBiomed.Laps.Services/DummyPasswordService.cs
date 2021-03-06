﻿using System;
using Lithnet.Laps.DirectoryInterfaces;

namespace KuLeuven.GBiomed.Laps.Services
{
    /// <summary>
    /// Dummy implementation of IPasswwordService for development purposes.
    /// </summary>
    public class DummyPasswordService : IPasswordService
    {
        public Password GetPassword(IComputer computer)
        {
            return new Password("NotTheRealPassword", null);
        }

        public void SetPasswordExpiryTime(IComputer computer, DateTime newDateTime)
        {
            // No expiry time for dummy password service.
        }
    }
}
