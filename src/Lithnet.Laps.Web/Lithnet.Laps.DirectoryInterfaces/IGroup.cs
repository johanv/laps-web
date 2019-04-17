using System;
using System.Security.Principal;

namespace Lithnet.Laps.DirectoryInterfaces
{
    public interface IGroup
    {
        Guid? Guid { get; }
        SecurityIdentifier Sid { get; }
    }
}
