using KuLeuven.GBiomed.Laps.Audit;
using Lithnet.Laps.ConfigSection;
using System.Collections.Generic;

namespace KuLeuven.GBiomed.Laps.Security.Authorization.ConfigurationFile
{
    public interface IAvailableReaders
    {
        IEnumerable<IReaderElement> GetReadersForTarget(ITarget target);
    }
}
