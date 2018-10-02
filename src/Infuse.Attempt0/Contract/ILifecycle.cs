using InfuseAttempt0.Enums;

namespace InfuseAttempt0.Contracts
{ 
    /// <summary>
    /// Container Lifecycle Managemnt contract
    /// </summary>
    internal interface ILifecycle
    {
        /// <summary>
        /// Tyoe of <see cref="LifecycleType"/>
        /// </summary>
        LifecycleType Lifecycle { get; }

        /// <summary>
        /// Contract to resolve an object registered with the <see cref="IContainer"/>
        /// </summary>
        /// <typeparam name="TInterface">Object Contract to resolve</typeparam>
        /// <returns></returns>
        TInterface Resolve<TInterface>();
    }
}
