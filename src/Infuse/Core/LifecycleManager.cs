using System.Collections.Generic;
using Infuse.Core.Lifecycle;

namespace Infuse.Core
{
    /// <summary>
    /// An Lifecycle manager
    /// </summary>
    internal class LifecycleManager : ILifecycleManager
    {
        private readonly Dictionary<LifecycleType, ILifecycle> _lifecycleStores = new Dictionary<LifecycleType, ILifecycle>();

        public LifecycleManager()
        {
            _lifecycleStores.Add(LifecycleType.Transient, new TransientLifecycle());
            _lifecycleStores.Add(LifecycleType.Singleton, new SingletonLifecycle());
        }

        /// <summary>
        /// Create an instance of <see cref="RegisteredObject.ConcreteType"/> and store it depending on <see cref="LifecycleType"/> for the instance
        /// </summary>
        /// <param name="regObject">Type of <see cref="RegisteredObject"/></param>
        /// <param name="args"><see cref="RegisteredObject.ConcreteType"/> constructor arguments</param>
        /// <returns>Instance of <see cref="RegisteredObject.ConcreteType"/></returns>
        public object CreateInstance(RegisteredObject regObject, params object[] args)
        {
            return _lifecycleStores[regObject.Lifecycle].CreateInstance(regObject, args);
        }

        /// <summary>
        /// Get instance of <see cref="RegisteredObject.InterfaceType"/>
        /// </summary>
        /// <param name="regObject">Type of <see cref="RegisteredObject"/></param>
        /// <returns>The instance from the store or null if not found </returns>
        public object GetInstance(RegisteredObject regObject)
        {
            return _lifecycleStores[regObject.Lifecycle].GetInstance(regObject);
        }

        /// <summary>
        /// Check if the instance exists in the store for <see cref="RegisteredObject.InterfaceType"/>
        /// </summary>
        /// <param name="regObject">Type of <see cref="RegisteredObject"/></param>
        /// <returns>True if found</returns>
        public bool IsRegistered(RegisteredObject regObject)
        {
            return _lifecycleStores[regObject.Lifecycle].IsRegistered(regObject);
        }
    }
}
