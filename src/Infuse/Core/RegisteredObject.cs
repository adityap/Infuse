using System;

namespace Infuse.Core
{
    /// <summary>
    /// Data model for storing the object registrations
    /// </summary>
    internal class RegisteredObject
    {
        /// <summary>
        /// <see cref="Type"/> of the object abstraction
        /// </summary>
        public Type InterfaceType { get; private set; }

        /// <summary>
        /// <see cref="Type"/> of the object implementation
        /// </summary>
        public Type ConcreteType { get; private set; }

        /// <summary>
        /// <see cref="LifecycleType"/> of the object
        /// </summary>
        public LifecycleType Lifecycle { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="interfaceType"><see cref="InterfaceType"/></param>
        /// <param name="concreteType"><see cref="ConcreteType"/></param>
        /// <param name="lifecycle"><see cref="LifecycleType"/></param>
        public RegisteredObject(Type interfaceType, Type concreteType, LifecycleType lifecycle)
        {
            InterfaceType = interfaceType;
            ConcreteType = concreteType;
            Lifecycle = lifecycle;
        }
    }
}