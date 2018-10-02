using InfuseAttempt0.Contracts;
using InfuseAttempt0.Enums;

namespace InfuseAttempt0.Extensions
{
    /// <summary>
    /// Extension method decorators for <see cref="IContainer"/>
    /// </summary>
    public static class ContainerExtensions
    {
        /// <summary>
        /// Decorator extension for registering Singletons of <see cref="LifecycleType"/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TImplementation</typeparam>
        /// <typeparam name="TImplementation">Class confirming to the TInterface contract</typeparam>
        /// <param name="container"><see cref="InfuseContainer"/></param>
        public static void RegisterSingleton<TInterface, TImplementation>(this IContainer container) where TImplementation : class, TInterface
        {
            container.Register<TInterface, TImplementation>(LifecycleType.Singleton);
        }

        /// <summary>
        /// Decorator extension for registering Transient of <see cref="LifecycleType"/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TImplementation</typeparam>
        /// <typeparam name="TImplementation">Class confirming to the TInterface contract</typeparam>
        /// <param name="container"><see cref="InfuseContainer"/></param>
        public static void RegisterTransient<TInterface, TImplementation>(this IContainer container) where TImplementation : class, TInterface
        {
            container.Register<TInterface, TImplementation>(LifecycleType.Transient);
        }
    }
}
