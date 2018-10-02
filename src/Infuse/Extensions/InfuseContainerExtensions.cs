namespace Infuse.Extensions
{
    /// <summary>
    /// Extension method decorators for <see cref="IContainer"/>
    /// </summary>
    public static class ContainerExtensions
    {
        /// <summary>
        /// Decorator extension for registering Singletons of <see cref="LifecycleType.Singleton"/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TConcrete</typeparam>
        /// <typeparam name="TConcrete">Class confirming to the TInterface contract</typeparam>
        /// <param name="container"><see cref="InfuseContainer"/></param>
        public static void RegisterSingleton<TInterface, TConcrete>(this IContainer container) where TConcrete : class, TInterface
        {
            container.Register<TInterface, TConcrete>(LifecycleType.Singleton);
        }

        /// <summary>
        /// Decorator extension for registering Transient of <see cref="LifecycleType.Transient"/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TConcrete</typeparam>
        /// <typeparam name="TConcrete">Class confirming to the TInterface contract</typeparam>
        /// <param name="container"><see cref="InfuseContainer"/></param>
        public static void RegisterTransient<TInterface, TConcrete>(this IContainer container) where TConcrete : class, TInterface
        {
            container.Register<TInterface, TConcrete>(LifecycleType.Transient);
        }
    }
}
