namespace Lithnet.Laps.ConfigSection
{
    public interface IReaderElement
    {
        AuditElement Audit { get; }
        string Principal { get; }
    }
}
