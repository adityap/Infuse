using System;

namespace Infuse
{
    /// <summary>
    /// IoC Container Interface
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Contract to register an object with the <see cref="IContainer"/> as default <see cref="LifecycleType.Transient"> </see>/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TConcrete</typeparam>
        /// <typeparam name="TConcrete">Class confirming to the TInterface contract</typeparam>
        void Register<TInterface, TConcrete>() where TConcrete : class, TInterface;

        /// <summary>
        /// Contract to register an object with the <see cref="IContainer"/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TConcrete</typeparam>
        /// <typeparam name="TConcrete">Class confirming to the TInterface contract</typeparam>
        /// <param name="lifeCycle"><see cref="LifecycleType"/> type for the object</param>
        void Register<TInterface, TConcrete>(LifecycleType lifeCycle) where TConcrete : class, TInterface;

        /// <summary>
        /// Contract to resolve an object with the <see cref="IContainer"/>
        /// </summary>
        /// <typeparam name="TInterface">Contract to TConcrete that needs to be resolved</typeparam>
        /// <returns>Implementation of the interface</returns>
        TInterface Resolve<TInterface>();

        /// <summary>
        /// Implentation to resolve an object with the <see cref="InfuseContainer"/>
        /// </summary>
        /// <param name="type"><see cref="Type"/> to resolve</param>
        /// <returns>Implementation of the interface</returns>
        object Resolve(Type type);
    }
}