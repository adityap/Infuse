using System;
using InfuseAttempt0.Contracts;
using InfuseAttempt0.Enums;
using InfuseAttempt0.Core;

namespace InfuseAttempt0.Factories
{
    /// <summary>
    /// Factory manager for <see cref="ILifecycle"/> implementations
    /// </summary>
    internal static class LifecycleFactory
    {
        /// <summary>
        /// A Factory method to return concrete implementations of <see cref="ILifecycle"/>
        /// </summary>
        /// <typeparam name="TInterface">Object's contract for which the <see cref="ILifecycle"/> instance is returned</typeparam>
        /// <param name="registrar"><see cref="IRegistryManager"/> instance required as a pass through to <see cref="ILifecycle"/> implementations</param>
        /// <returns>Instance of <see cref="ILifecycle"/> implementations depending on the object interface's <see cref="LifecycleType"/></returns>
        /// <exception cref="InvalidOperationException">If not a valid type of <see cref="LifecycleType"/></exception>
        internal static ILifecycle GetLifecycleInstance<TInterface>(IRegistryManager registrar)
        {
            var existingRegistration = registrar.Find<TInterface>();

            switch (existingRegistration.Lifecycle)
            {
                case LifecycleType.Singleton:
                    return new SingletonLifecycle(registrar);
                case LifecycleType.Transient:
                    return new TransientLifecycle(registrar);
                default:
                    throw new InvalidOperationException($"LifecycleType {existingRegistration.Lifecycle} invalid!");
            }
        }
    }
}
