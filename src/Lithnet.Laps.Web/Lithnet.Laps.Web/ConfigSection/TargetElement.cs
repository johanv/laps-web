using System.Configuration;
using Lithnet.Laps.Web.Audit;
using Lithnet.Laps.Web.Models;

namespace Lithnet.Laps.Web
{
    public class TargetElement : ConfigurationElement, ITarget
    {
        private const string PropAudit = "audit";
        private const string PropReaders = "readers";
        private const string PropReader = "reader";
        private const string PropExpireAfter = "expire-after";
        private const string PropID = "name";
        private const string PropIDType = "type";

        [ConfigurationProperty(TargetElement.PropAudit, IsRequired = false)]
        public AuditElement Audit => (AuditElement) this[TargetElement.PropAudit];

        [ConfigurationProperty(PropIDType, IsRequired = false)]
        public TargetType Type => (TargetType) this[PropIDType];

        [ConfigurationProperty(PropID, IsRequired = true, IsKey = true)]
        public string Name => (string) this[PropID];

        [ConfigurationProperty(TargetElement.PropExpireAfter, IsRequired = false)]
        public string ExpireAfter => (string) this[TargetElement.PropExpireAfter];

        [ConfigurationProperty(PropReaders, IsRequired = true)]
        [ConfigurationCollection(typeof(ReaderCollection), AddItemName = PropReader, CollectionType = ConfigurationElementCollectionType.BasicMap)]
        public ReaderCollection Readers => (ReaderCollection) this[PropReaders];

        TargetType ITarget.TargetType => Type;

        string ITarget.TargetName => Name;

        string ITarget.ExpireAfter => ExpireAfter;

        UsersToNotify ITarget.UsersToNotify => Audit.UsersToNotify;
    }
}