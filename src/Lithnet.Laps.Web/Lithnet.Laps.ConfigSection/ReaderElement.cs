using System.Configuration;

namespace Lithnet.Laps.ConfigSection
{
    public class ReaderElement : ConfigurationElement, IReaderElement
    {
        private const string PropAudit = "audit";
        private const string PropPrincipal = "principal";

        [ConfigurationProperty(ReaderElement.PropAudit, IsRequired = false)]
        public AuditElement Audit => (AuditElement)this[ReaderElement.PropAudit];

        [ConfigurationProperty(PropPrincipal, IsRequired = true, IsKey = true)]
        public string Principal => (string)this[PropPrincipal];
    }
}