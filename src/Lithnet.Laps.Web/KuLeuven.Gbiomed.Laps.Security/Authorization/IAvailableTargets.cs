using KuLeuven.GBiomed.Laps.Audit;
using Lithnet.Laps.DirectoryInterfaces;

namespace KuLeuven.GBiomed.Laps.Security.Authorization
{
    public interface IAvailableTargets
    {
        ITarget GetMatchingTargetOrNull(IComputer computer);
    }
}
