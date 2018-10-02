using System;

namespace Infuse.Core
{
    /// <summary>
    /// A contract for container's registry manager
    /// </summary>
    internal interface IRegistryManager
    {
        /// <summary>
        /// Add the container's object registry
        /// </summary>
        /// <typeparam name="TInterface">Objects's contract</typeparam>
        /// <typeparam name="TConcrete">Contracts implementation</typeparam>
        /// <param name="lifecycle"><see cref="LifecycleType"/> of the object</param>
        void Add<TInterface, TConcrete>(LifecycleType lifecycle) where TConcrete : class, TInterface;

        /// <summary>
        /// Get instance of the object's contract
        /// </summary>
        /// <param name="type">Objects's type to search for</param>
        /// <returns>Implementation instance of type</returns>
        object GetInstance(Type type);

        /// <summary>
        /// Get instance of the object's contract
        /// </summary>
        /// <typeparam name="TInterface">Objects's contract to search for</typeparam>
        /// <returns></returns>
        TInterface GetInstance<TInterface>();


    }
}
