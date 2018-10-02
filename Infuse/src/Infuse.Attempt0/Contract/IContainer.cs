using InfuseAttempt0.Enums;

namespace InfuseAttempt0.Contracts
{
    /// <summary>
    /// IoC Container Interface
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Contract to register an object with the <see cref="IContainer"/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TImplementation</typeparam>
        /// <typeparam name="TImplementation">Class confirming to the TInterface contract</typeparam>
        /// <param name="lifecycleType"><see cref="LifecycleType"/> type for the object</param>
        void Register<TInterface, TImplementation>(LifecycleType lifecycleType = LifecycleType.Transient) where TImplementation : class, TInterface;

        /// <summary>
        /// Contract to resolve an object with the <see cref="IContainer"/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TImplementation that needs to be resolved</typeparam>
        /// <returns>Implementation of the interface</returns>
        TInterface Resolve<TInterface>();
    }
}
