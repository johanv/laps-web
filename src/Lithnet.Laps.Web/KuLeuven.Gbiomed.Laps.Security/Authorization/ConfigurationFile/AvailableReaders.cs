using KuLeuven.GBiomed.Laps.Audit;
using Lithnet.Laps.ConfigSection;
using System.Collections.Generic;
using System.Linq;

namespace KuLeuven.GBiomed.Laps.Security.Authorization.ConfigurationFile
{
    public class AvailableReaders: IAvailableReaders
    {
        private readonly ILapsConfig configSection;

        public AvailableReaders(ILapsConfig configSection)
        {
            this.configSection = configSection;
        }

        public IEnumerable<IReaderElement> GetReadersForTarget(ITarget target)
        {
            var targetElementCollection = configSection.Targets;

            var query = from targetElement in targetElementCollection.OfType<TargetElement>()
                where targetElement.Name == target.TargetName
                select targetElement.Readers;

            var readerCollection = query.FirstOrDefault();

            if (readerCollection == null)
            {
                return new ReaderElement[0];
            }

            return readerCollection.OfType<ReaderElement>();
        }
    }
}