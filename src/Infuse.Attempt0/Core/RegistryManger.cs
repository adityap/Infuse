using System;
using System.Collections.Generic;
using System.Linq;
using InfuseAttempt0.Models;
using InfuseAttempt0.Contracts;
using InfuseAttempt0.Enums;
using System.Reflection;

namespace InfuseAttempt0.Core
{
    /// <summary>
    /// Concrete implementation to <see cref="IRegistryManager"/>
    /// </summary>
    internal class RegistryManger : IRegistryManager
    {
        /// <summary>
        /// A collection of <see cref="RegisteredObject"/>
        /// </summary>
        private IList<RegisteredObject> _objectRegistry = new List<RegisteredObject>();

        /// <summary>
        /// Add or Update the container's object registry
        /// </summary>
        /// <typeparam name="TInterface">Objects's contract</typeparam>
        /// <typeparam name="TImplementation">Contracts implementation</typeparam>
        /// <param name="lifecycleType"><see cref="LifecycleType"/> of the object</param>
        public void AddOrUpdate<TInterface, TImplementation>(LifecycleType lifecycleType) where TImplementation : class, TInterface
        {
            var interfaceType = typeof(TInterface);
            var existingRegistration = _objectRegistry.FirstOrDefault(registration => registration.Interface == interfaceType);

            if (existingRegistration == null)
            {
                _objectRegistry.Add(new RegisteredObject(typeof(TInterface), typeof(TImplementation), lifecycleType));
            }
            else
            {
                existingRegistration.Update(typeof(TImplementation), lifecycleType);
            }
        }

        /// <summary>
        /// Find First or default <see cref="RegisteredObject"/> in the registry
        /// </summary>
        /// <param name="predicate">Function to search for the object</param>
        /// <returns></returns>
        public RegisteredObject FirstOrDefault(Func<RegisteredObject, bool> predicate)
        {
            return _objectRegistry.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Find <see cref="RegisteredObject"/> in the registry
        /// </summary>
        /// <typeparam name="TInterface">Objects's contract to search for</typeparam>
        /// <returns></returns>
        public RegisteredObject Find<TInterface>()
        {
            var interfaceType = typeof(TInterface);
            return this.Find(interfaceType);
        }

        /// <summary>
        /// Find the <see cref="RegisteredObject"/> for the given <see cref="Type"/>
        /// </summary>
        /// <param name="interfaceType"><see cref="Type"/> to find</param>
        /// <returns><see cref="RegisteredObject"/> instance</returns>
        /// <exception cref="ArgumentNullException">If the supplied <see cref="Type"/> is null</exception>
        /// <exception cref="ArgumentException">If the supplied type is not registered with <see cref="RegistryManger"/></exception>
        private RegisteredObject Find(Type interfaceType)
        {
            if (interfaceType == null)
            {
                throw new ArgumentNullException($"Interface type argument is null");
            }

            var registration = this.FirstOrDefault(reg => reg.Interface == interfaceType);

            if (registration == null)
            {
                throw new ArgumentException($"Unable to find implementation for {interfaceType.FullName}");
            }

            return registration;
        }

        #region Get Instance
        
        /// <summary>
        /// Get instance of the object's contract
        /// </summary>
        /// <typeparam name="TInterface">Objects's contract to search for</typeparam>
        /// <returns></returns>
        public TInterface GetInstance<TInterface>()
        {
            var interfaceType = typeof(TInterface);
            return (TInterface)ResolveType(interfaceType);
        }

        /// <summary>
        /// Resolve the object for the given <see cref="Type"/>
        /// </summary>
        /// <param name="interfaceType"><see cref="Type"/></param>
        /// <returns></returns>
        private object ResolveType(Type interfaceType)
        {
            var registration = this.Find(interfaceType);

            return ResolveObject(registration);
        }

        /// <summary>
        /// Resolve object hierarchy for the Implementation type of <see cref="RegisteredObject"/> 
        /// </summary>
        /// <param name="regObject"><see cref="RegisteredObject"/></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">If the <see cref="RegisteredObject.ConcreteType"/> does not have a public constructor</exception>
        private object ResolveObject(RegisteredObject regObject)
        {
            var constructor = regObject.Implementation.GetConstructors().FirstOrDefault();

            if (constructor == null)
                throw new InvalidOperationException($"A public constructor not found for {regObject.Implementation.FullName}");

            var parameters = constructor.GetParameters();

            if (!parameters.Any())
            {
                return CreateInstance(regObject.Implementation);
            }
            else
            {
                var instances = ResolveConstructorParameters(regObject);
                return CreateInstance(regObject.Implementation, instances.ToArray());
            }
        }

        /// <summary>
        /// Resolve constructor parameters for the Implementation type <see cref="RegisteredObject"/> 
        /// </summary>
        /// <param name="registeredObject"><see cref="RegisteredObject"/></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">If the <see cref="RegisteredObject.ConcreteType"/> does not have a public constructor</exception>
        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.Implementation.GetConstructors().FirstOrDefault();

            if (constructorInfo == null)
                throw new InvalidOperationException($"A public constructor not found for {registeredObject.Implementation.FullName}");

            foreach (var parameter in constructorInfo.GetParameters())
            {
                yield return ResolveType(parameter.ParameterType);
            }
        }

        /// <summary>
        /// Create instance of specified type
        /// </summary>
        /// <param name="type"><see cref="Type"/> for which the instance will be createc</param>
        /// <param name="parameters">array of parameters required for type instantiation</param>
        /// <returns></returns>
        private object CreateInstance(Type type, params object[] parameters)
        {
            return Activator.CreateInstance(type, parameters.Any() ? parameters : null);
        }         
         
        #endregion

        #region Original
        /*
        public TInterface GetInstance<TInterface>()
        {
            var interfaceType = typeof(TInterface);
            RegisteredObject registration = FindRegistration(interfaceType);
            var constructor = registration.Implementation.GetConstructors().First();

            var parameters = constructor.GetParameters();

            if (!parameters.Any())
            {
                return (TInterface)CreateInstance(registration.Implementation);
            }
            else
            {
                var instances = new List<object>();
                GatherConstructorParameterInstances(ref instances, parameters);
                return (TInterface)CreateInstance(registration.Implementation, instances.ToArray());
            }
        }

        private RegisteredObject FindRegistration(Type interfaceType)
        {
            if (interfaceType == null)
            {
                throw new ArgumentNullException($"Interface type argument is null");

            }
            var registration = _objectRegistry.FirstOrDefault(reg => reg.Interface == interfaceType);

            if (registration == null)
            {
                throw new ArgumentException($"Unable to find implementation for {interfaceType.Name}");
            }

            return registration;
        }

        private void GatherConstructorParameterInstances(ref List<object> instances, ParameterInfo[] parameters)
        {
            foreach (var parameter in parameters)
            {
                var registrationForParameter = FindRegistration(parameter.ParameterType);
                var parameterConstructor = registrationForParameter.Implementation.GetConstructors().First();
                var parameterConstructorArguments = parameterConstructor.GetParameters();
                if (parameterConstructorArguments.Any())
                {
                    foreach (var parameterConstructorArgument in parameterConstructorArguments)
                    {
                        var parameterConstructorInstances = new List<object>();
                        GatherConstructorParameterInstances(ref parameterConstructorInstances, parameterConstructorArguments);
                        instances.Add(CreateInstance(registrationForParameter.Implementation, parameterConstructorInstances.ToArray()));
                    }
                }
                else
                {
                    instances.Add(CreateInstance(registrationForParameter.Implementation));
                }
            }
        }

        private object CreateInstance(Type type, params object[] parameters)
        {
            return Activator.CreateInstance(type, parameters.Any() ? parameters : null);
        }         
         */
        #endregion
    }
}
