using System;

namespace Infuse.Core.Lifecycle
{
    /// <summary>
    /// An implementation to <see cref="ILifecycle"/> for <see cref="LifecycleType.Transient"/>
    /// </summary>
    internal class TransientLifecycle : ILifecycle
    {
        /// <summary>
        /// Create an instance of <see cref="RegisteredObject.ConcreteType"/>
        /// </summary>
        /// <param name="regObject">Type of <see cref="RegisteredObject"/></param>
        /// <param name="args"><see cref="RegisteredObject.ConcreteType"/> constructor arguments</param>
        /// <returns>Instance of <see cref="RegisteredObject.ConcreteType"/></returns>
        public object CreateInstance(RegisteredObject regObject, params object[] args)
        {
            return Activator.CreateInstance(regObject.ConcreteType, args);
        }

        /// <summary>
        /// Use <see cref="CreateInstance(RegisteredObject, object[])"/> instead for <see cref="LifecycleType.Transient"/>
        /// </summary>
        /// <param name="regObject">Type of <see cref="RegisteredObject"/></param>
        /// <returns>null</returns>
        public object GetInstance(RegisteredObject regObject)
        {
            return null;
            //throw new NullReferenceException($"You can GetInstance of a Transient type. Use CreateInstance instead!");
        }

        /// <summary>
        /// <see cref="LifecycleType.Transient"/> types are not stored. This method will return false always
        /// </summary>
        /// <param name="regObject">Type of <see cref="RegisteredObject"/></param>
        /// <returns>false</returns>
        public bool IsRegistered(RegisteredObject regObject)
        {
            return false;
        }
    }
}
