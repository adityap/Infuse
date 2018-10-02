using InfuseAttempt0.Contracts;
using InfuseAttempt0.Enums;
using InfuseAttempt0.Core;
using InfuseAttempt0.Factories;

namespace InfuseAttempt0
{
    /// <summary>
    /// A concrete implementation to <see cref="IContainer"/>
    /// </summary>
    public class InfuseContainer: IContainer
    {
        /// <summary>
        /// <see cref="RegistryManger"/> for managing the container objects
        /// </summary>
        private IRegistryManager _registrar = new RegistryManger();

        /// <summary>
        /// Implementation to register an object with the <see cref="InfuseContainer"/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TImplementation</typeparam>
        /// <typeparam name="TImplementation">Class confirming to the TInterface contract</typeparam>
        /// <param name="lifecycleType"><see cref="LifecycleType"/> type for the object</param>
        public void Register<TInterface, TImplementation>(LifecycleType lifecycleType = LifecycleType.Transient) where TImplementation : class, TInterface
        {
            _registrar.AddOrUpdate<TInterface, TImplementation>(lifecycleType);
        }

        /// <summary>
        /// Implentation to resolve an object with the <see cref="InfuseContainer"/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TImplementation that needs to be resolved</typeparam>
        /// <returns>Implementation of the interface</returns>
        public TInterface Resolve<TInterface>()
        {
            var lifecycleInstance = LifecycleFactory.GetLifecycleInstance<TInterface>(_registrar);
            return lifecycleInstance.Resolve<TInterface>();
        }
    }
}
