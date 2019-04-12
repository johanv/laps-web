using System;

namespace Lithnet.Laps.DirectoryInterfaces
{
    public interface IGroup
    {
        Guid? Guid { get; }
        SecurityIdentifier Sid { get; }
    }
}
