using System;
using InfuseAttempt0.Enums;

namespace InfuseAttempt0.Models
{
    /// <summary>
    /// Data model for storing the object registrations
    /// </summary>
    internal class RegisteredObject
    {
        /// <summary>
        /// <see cref="Type"/> of the object abstraction
        /// </summary>
        internal Type Interface { get; private set; }

        /// <summary>
        /// <see cref="Type"/> of the object implementation
        /// </summary>
        internal Type Implementation { get; private set; }

        /// <summary>
        /// <see cref="LifecycleType"/> of the object
        /// </summary>
        internal LifecycleType Lifecycle { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="interfaceType"><see cref="Interface"/></param>
        /// <param name="implementation"><see cref="Implementation"/></param>
        /// <param name="lifecycle"><see cref="LifecycleType"/></param>
        internal RegisteredObject(Type interfaceType, Type implementation, LifecycleType lifecycle)
        {
            Interface = interfaceType;
            Implementation = implementation;
            Lifecycle = lifecycle;
        }

        /// <summary>
        /// Update the Implementation and Lifecycle type for the object
        /// </summary>
        /// <param name="implementation"><see cref="Implementation"/></param>
        /// <param name="lifecycle"><see cref="Lifecycle"/></param>
        internal void Update(Type implementation, LifecycleType lifecycle)
        {
            Implementation = implementation;
            Lifecycle = lifecycle;
        }
    }
}
