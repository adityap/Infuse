using System;
using System.Collections.Generic;
using System.Linq;

namespace Infuse.Core
{
    /// <summary>
    /// An implementation of <see cref="IRegistryManager"/>
    /// </summary>
    internal class RegistryManager: IRegistryManager
    {
        /// <summary>
        /// A collection of <see cref="RegisteredObject"/>
        /// </summary>
        private readonly IList<RegisteredObject> _objectRegistry = new List<RegisteredObject>();

        /// <summary>
        /// A Lifecyle manager <see cref="ILifecycleManager"/>
        /// </summary>
        private readonly ILifecycleManager _instanceManager = new LifecycleManager();

        /// <summary>
        /// Add the container's object registry
        /// </summary>
        /// <typeparam name="TInterface">Objects's contract</typeparam>
        /// <typeparam name="TConcrete">Contracts implementation</typeparam>
        /// <param name="lifecycle"><see cref="LifecycleType"/> of the object</param>
        /// <exception cref="ArgumentException"> if type of TInterface already exists in the object registry</exception>
        public void Add<TInterface, TConcrete>(LifecycleType lifecycle) where TConcrete : class, TInterface
        {
            var interfaceType = typeof(TInterface);
            var existingRegistration = _objectRegistry.FirstOrDefault(registration => registration.InterfaceType == interfaceType);

            if (existingRegistration == null)
            {
                _objectRegistry.Add(new RegisteredObject(typeof(TInterface), typeof(TConcrete), lifecycle));
            }
            else
            {
                throw new ArgumentException($"The type {interfaceType.FullName} has been registered already!");
            }
        }

        /// <summary>
        /// Get instance of the object's contract
        /// </summary>
        /// <param name="type">Objects's type to search for</param>
        /// <returns>Implementation instance of type</returns>
        public object GetInstance(Type type)
        {
            return ResolveObject(type);
        }

        /// <summary>
        /// Get instance of the object's contract
        /// </summary>
        /// <typeparam name="TInterface">Objects's contract to search for</typeparam>
        /// <returns></returns>
        public TInterface GetInstance<TInterface>()
        {
            return (TInterface)ResolveObject(typeof(TInterface));
        }

        /// <summary>
        /// Resolve the object for the given <see cref="Type"/>
        /// </summary>
        /// <param name="interfaceType"><see cref="Type"/></param>
        /// <returns>oject of the type</returns>
        /// <exception cref="ArgumentException"> if the interfaceType is not found in registry</exception>
        private object ResolveObject(Type interfaceType)
        {
            var registeredObject = _objectRegistry.FirstOrDefault(o => o.InterfaceType == interfaceType);
            if (registeredObject == null)
            {
                throw new ArgumentException($"The type {interfaceType.FullName} has not been registered!");
            }
            return ResolveInstance(registeredObject);
        }

        /// <summary>
        /// Resolve object hierarchy for the Implementation type of <see cref="RegisteredObject"/> 
        /// </summary>
        /// <param name="regObject"><see cref="RegisteredObject"/></param>
        /// <returns>object of the type</returns>
        private object ResolveInstance(RegisteredObject regObject)
        {
            if (!_instanceManager.IsRegistered(regObject))
            {
                var parameters = ResolveConstructorParameters(regObject);
                return _instanceManager.CreateInstance(regObject, parameters.ToArray());
            }
            return _instanceManager.GetInstance(regObject);
        }

        /// <summary>
        /// Resolve constructor parameters for the Implementation type <see cref="RegisteredObject"/> 
        /// </summary>
        /// <param name="registeredObject"><see cref="RegisteredObject"/></param>
        /// <returns><see cref="IEnumerable{T}"/> of the constructor parameters</returns>
        /// <exception cref="InvalidOperationException">If the <see cref="RegisteredObject.ConcreteType"/> does not have a public constructor</exception>
        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            //TODO: Currently support only Public Ctor types. In Future add other types e.g.:internal
            var constructorInfo = registeredObject.ConcreteType.GetConstructors().FirstOrDefault();

            if (constructorInfo == null)
                throw new InvalidOperationException($"A public constructor not found for {registeredObject.ConcreteType.FullName}");

            foreach (var parameter in constructorInfo.GetParameters())
            {
                yield return ResolveObject(parameter.ParameterType);
            }
        }
    }
}
