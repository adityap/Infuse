using System;
using InfuseAttempt0.Enums;
using InfuseAttempt0.Models;

namespace InfuseAttempt0.Contracts
{
    /// <summary>
    /// A contract for container's registry manager
    /// </summary>
    internal interface IRegistryManager
    {
        /// <summary>
        /// Add or Update the container's object registry
        /// </summary>
        /// <typeparam name="TInterface">Objects's contract</typeparam>
        /// <typeparam name="TImplementation">Contracts implementation</typeparam>
        /// <param name="lifecycleType"><see cref="LifecycleType"/> of the object</param>
        void AddOrUpdate<TInterface, TImplementation>(LifecycleType lifecycleType) where TImplementation : class, TInterface;

        /// <summary>
        /// Find First or default <see cref="RegisteredObject"/> in the registry
        /// </summary>
        /// <param name="predicate">Function to search for the object</param>
        /// <returns></returns>
        RegisteredObject FirstOrDefault(Func<RegisteredObject, bool> predicate);

        /// <summary>
        /// Find <see cref="RegisteredObject"/> in the registry
        /// </summary>
        /// <typeparam name="TInterface">Objects's contract to search for</typeparam>
        /// <returns></returns>
        RegisteredObject Find<TInterface>();

        /// <summary>
        /// Get instance of the object's contract
        /// </summary>
        /// <typeparam name="TInterface">Objects's contract to search for</typeparam>
        /// <returns></returns>
        TInterface GetInstance<TInterface>();
    }
}
