using InfuseAttempt0.Contracts;
using InfuseAttempt0.Enums;

namespace InfuseAttempt0.Core
{
    /// <summary>
    /// Abstract Lifecycle
    /// </summary>
    internal abstract class AbstractLifecycle : ILifecycle
    {
        /// <summary>
        /// Reference to hold the <see cref="IRegistryManager"/>
        /// </summary>
        private readonly IRegistryManager _objectRegistry;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="registrar"></param>
        protected AbstractLifecycle(IRegistryManager registrar)
        {
            this._objectRegistry = registrar;
        }

        /// <summary>
        /// <see cref="LifecycleType"/> type of the concrete Lifecycle implementation
        /// </summary>
        public abstract LifecycleType Lifecycle { get; }

        /// <summary>
        /// Default implemnetation for object resolution
        /// </summary>
        /// <typeparam name="TInterface">Object's contract to resolve</typeparam>
        /// <returns></returns>
        public virtual TInterface Resolve<TInterface>()
        {
            return _objectRegistry.GetInstance<TInterface>();
        }
    }
}
