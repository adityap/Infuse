namespace Infuse.Core.Lifecycle
{
    /// <summary>
    /// A contract for Store of <see cref="LifecycleType"/>
    /// </summary>
    internal interface ILifecycle
    {
        /// <summary>
        /// Create an instance of <see cref="RegisteredObject.ConcreteType"/> and store it depending on <see cref="LifecycleType"/> for the instance
        /// </summary>
        /// <param name="regObject">Type of <see cref="RegisteredObject"/></param>
        /// <param name="args"><see cref="RegisteredObject.ConcreteType"/> constructor arguments</param>
        /// <returns>Instance of <see cref="RegisteredObject.ConcreteType"/></returns>
        object CreateInstance(RegisteredObject regObject, params object[] args);

        /// <summary>
        /// Get instance of <see cref="RegisteredObject.InterfaceType"/>
        /// </summary>
        /// <param name="regObject">Type of <see cref="RegisteredObject"/></param>
        /// <returns>The instance from the store or null if not found </returns>
        object GetInstance(RegisteredObject regObject);

        /// <summary>
        /// Check if the instance exists in the store for <see cref="RegisteredObject.InterfaceType"/>
        /// </summary>
        /// <param name="regObject">Type of <see cref="RegisteredObject"/></param>
        /// <returns>True if found</returns>
        bool IsRegistered(RegisteredObject regObject);

    }
}
