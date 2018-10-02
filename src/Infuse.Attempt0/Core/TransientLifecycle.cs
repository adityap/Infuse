using InfuseAttempt0.Contracts;
using InfuseAttempt0.Enums;

namespace InfuseAttempt0.Core
{
    /// <summary>
    /// Trainsient Lifecycle management for the container
    /// </summary>
    internal class TransientLifecycle : AbstractLifecycle
    {
        /// <summary>
        /// Trainsient Lifecycle type
        /// </summary>
        public override LifecycleType Lifecycle
        {
            get { return LifecycleType.Transient; }
        }

        /// <summary>
        /// Trainsient Lifecycle Constructor
        /// </summary>
        /// <param name="registrar"><see cref="IRegistryManager"/> instance</param>
        internal TransientLifecycle(IRegistryManager registrar) 
            : base(registrar)
        {
        }
    }
}
