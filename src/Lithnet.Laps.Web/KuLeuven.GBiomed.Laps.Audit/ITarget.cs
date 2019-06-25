namespace KuLeuven.GBiomed.Laps.Audit
{
    /// <summary>
    /// The target is an OU containing computers of which we'll be able to extract the password.
    /// 
    /// FIXME: This interface seems to be in the wrong assembly.
    /// </summary>
    public interface ITarget
    {
        TargetType TargetType { get; }
        string TargetName { get; }
        /// <summary>
        /// Password expiration time, formatted as HH:MM:ss.
        ///
        /// FIXME: I guess there is a better type than string to represent this.
        /// </summary>
        string ExpireAfter { get; }
        UsersToNotify UsersToNotify { get; }
    }
}
