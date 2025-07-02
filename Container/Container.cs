using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        /// <summary>
        /// A simple dependency injection container that allows binding interfaces to implementations.
        /// and retrieving instances of those implementations.
        /// </summary>
        private readonly Dictionary<Type, Func<object>> _registrations = new();

        /// <summary>
        /// Registers a binding between an interface type and its implementation type.
        /// After binding, you can retrieve instances of the implementation type using the interface type.
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <param name="implementationType"></param>
        public void Bind(Type interfaceType, Type implementationType) 
        {
            _registrations[interfaceType] = () => Activator.CreateInstance(implementationType);
        }

        /// <summary>
        /// Retrieves an instance of the registered type for the specified generic type parameter.
        /// After binding an interface to an implementation, you can use this method to get an instance of the implementation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Get<T>()
        {
            if (_registrations.TryGetValue(typeof(T), out var factory))
            {
                return (T)factory();
            }

            throw new InvalidOperationException($"Service of type {typeof(T)} is not registered.");
        }    
    }
}