using KuLeuven.GBiomed.Laps.Audit;

namespace Lithnet.Laps.ConfigSection
{
    public interface ILapsConfig
    {
        TargetCollection Targets { get; }
        RateLimitIPElement RateLimitIP { get; }
        RateLimitUserElement RateLimitUser { get; }
        UsersToNotify UsersToNotify { get; }
    }
}
