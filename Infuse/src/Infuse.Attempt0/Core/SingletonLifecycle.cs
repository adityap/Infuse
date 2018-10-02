using System;
using System.Collections.Concurrent;
using InfuseAttempt0.Contracts;
using InfuseAttempt0.Enums;

namespace InfuseAttempt0.Core
{
    /// <summary>
    /// Singleton Lifecycle management for container
    /// </summary>
    internal class SingletonLifecycle : AbstractLifecycle
    {
        /// <summary>
        /// ConcurrentDictionary data strcuture to manage singleton instances of the container objects
        /// </summary>
        private static ConcurrentDictionary<Type, object> instances = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Singleton Lifecycle type
        /// </summary>
        public override LifecycleType Lifecycle
        {
            get { return LifecycleType.Singleton; }
        }

        /// <summary>
        /// Singleton Lifecycle Constructor
        /// </summary>
        /// <param name="registrar"><see cref="IRegistryManager"/> instance</param>
        internal SingletonLifecycle(IRegistryManager registrar) 
            : base(registrar)
        { }

        /// <summary>
        /// Singleton's specific implementation for resolving object contract
        /// </summary>
        /// <typeparam name="TInterface">Object's contract to resolve</typeparam>
        /// <returns></returns>
        public override TInterface Resolve<TInterface>()
        {
            var interfaceType = typeof(TInterface);
            if (instances.ContainsKey(interfaceType))
            {
                return (TInterface)instances[interfaceType];
            }
            else
            {
                var instance = base.Resolve<TInterface>();
                instances[interfaceType] = instance;
                return instance;
            }            
        }
    }
}
