using System;
using System.Collections.Concurrent;

namespace Infuse.Core.Lifecycle
{
    /// <summary>
    /// An implementation to <see cref="ILifecycle"/> for <see cref="LifecycleType.Singleton"/>
    /// </summary>
    internal class SingletonLifecycle : ILifecycle
    {
        /// <summary>
        /// A <see cref="ConcurrentDictionary{TKey, TValue}"/> collection for <see cref="LifecycleType.Singleton"/> object management
        /// </summary>
        private readonly ConcurrentDictionary<Type, object> _singletonStore = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Create an instance of <see cref="RegisteredObject.ConcreteType"/> and store it depending on <see cref="LifecycleType"/> for the instance
        /// </summary>
        /// <param name="regObject">Type of <see cref="RegisteredObject"/></param>
        /// <param name="args"><see cref="RegisteredObject.ConcreteType"/> constructor arguments</param>
        /// <returns>Instance of <see cref="RegisteredObject.ConcreteType"/></returns>
        public object CreateInstance(RegisteredObject regObject, params object[] args)
        {
            object concrete = Activator.CreateInstance(regObject.ConcreteType, args);
            _singletonStore[regObject.InterfaceType] = concrete;
            return concrete;
        }

        /// <summary>
        /// Get instance of <see cref="RegisteredObject.InterfaceType"/>
        /// </summary>
        /// <param name="regObject">Type of <see cref="RegisteredObject"/></param>
        /// <returns>The instance from the store or null if not found </returns>
        public object GetInstance(RegisteredObject regObject)
        {
            if (IsRegistered(regObject))
                return _singletonStore[regObject.InterfaceType];
            return null;
        }

        /// <summary>
        /// Check if the instance exists in the store for <see cref="RegisteredObject.InterfaceType"/>
        /// </summary>
        /// <param name="regObject">Type of <see cref="RegisteredObject"/></param>
        /// <returns>True if found</returns>
        public bool IsRegistered(RegisteredObject regObject)
        {
            return _singletonStore.ContainsKey(regObject.InterfaceType);
        }
    }
}
