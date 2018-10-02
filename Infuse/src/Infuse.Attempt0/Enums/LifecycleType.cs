namespace InfuseAttempt0.Enums
{
    /// <summary>
    /// Enum describing <see cref="LifecycleType"/> for the object registered with <see cref="IContainer"/>
    /// </summary>
    public enum LifecycleType
    {
        /// <summary>
        /// A new instance for every request
        /// </summary>
        Transient,

        /// <summary>
        /// Single instance across request
        /// </summary>
        Singleton
    }
}
