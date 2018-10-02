using Infuse.Core;
using System;

namespace Infuse
{
    /// <summary>
    /// A concrete implementation to <see cref="IContainer"/>
    /// </summary>
    public class InfuseContainer : IContainer
    {
        /// <summary>
        /// <see cref="RegistryManager"/> for managing the container objects
        /// </summary>
        private readonly IRegistryManager _registrar = new RegistryManager();

        /// <summary>
        /// Implementation to register an object with the <see cref="InfuseContainer"/> as default <see cref="LifecycleType.Transient" />
        /// </summary>
        /// <typeparam name="TInterface">Contract to TConcrete</typeparam>
        /// <typeparam name="TConcrete">Class confirming to the TInterface contract</typeparam>
        public void Register<TInterface, TConcrete>() where TConcrete : class, TInterface
        {
            Register<TInterface, TConcrete>(LifecycleType.Transient);
        }

        /// <summary>
        /// Implementation to register an object with the <see cref="InfuseContainer"/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TConcrete</typeparam>
        /// <typeparam name="TConcrete">Class confirming to the TInterface contract</typeparam>
        /// <param name="lifecycle"><see cref="LifecycleType"/> type for the object</param>
        public void Register<TInterface, TConcrete>(LifecycleType lifecycle) where TConcrete : class, TInterface
        {
            _registrar.Add<TInterface, TConcrete>(lifecycle);
        }

        /// <summary>
        /// Implentation to resolve an object with the <see cref="InfuseContainer"/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TConcrete that needs to be resolved</typeparam>
        /// <returns>Implementation of the interface</returns>
        public TInterface Resolve<TInterface>()
        {
            return _registrar.GetInstance<TInterface>();
        }

        /// <summary>
        /// Implentation to resolve an object with the <see cref="InfuseContainer"/>
        /// </summary>
        /// <param name="type"><see cref="Type"/> to resolve</param>
        /// <returns>Implementation of the interface</returns>
        public object Resolve(Type type)
        {
            return _registrar.GetInstance(type);
        }
    }
}