﻿using System;
using System.Reflection;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 14:12:32
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public interface IObjectContainer
    {
        /// <summary>Register a implementation type.
        /// </summary>
        /// <param name="implementationType">The implementation type.</param>
        /// <param name="serviceName">The service name.</param>
        /// <param name="life">The life cycle of the implementer type.</param>
        void RegisterType(Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton);

        /// <summary>Register a implementer type as a service implementation.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <param name="implementationType">The implementation type.</param>
        /// <param name="serviceName">The service name.</param>
        /// <param name="life">The life cycle of the implementer type.</param>
        void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton);

        /// <summary>Register a implementer type as a service implementation.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <typeparam name="TImplementer">The implementer type.</typeparam>
        /// <param name="serviceName">The service name.</param>
        /// <param name="life">The life cycle of the implementer type.</param>
        void Register<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService;

        /// <summary>Register a implementer type instance as a service implementation.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <typeparam name="TImplementer">The implementer type.</typeparam>
        /// <param name="instance">The implementer type instance.</param>
        /// <param name="serviceName">The service name.</param>
        void RegisterInstance<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService;

        /// <summary>
        /// Register Assembly
        /// </summary>
        /// <param name="assemblies"></param>
        /// <param name="predicate"></param>
        void RegisterAssemblyTypes(Assembly assemblies, Func<Type, bool> predicate = null);

        /// <summary>Resolve a service.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <returns>The component instance that provides the service.</returns>
        TService Resolve<TService>() where TService : class;

        /// <summary>Resolve a service.
        /// </summary>
        /// <param name="serviceType">The service type.</param>
        /// <returns>The component instance that provides the service.</returns>
        object Resolve(Type serviceType);

        /// <summary>Try to retrieve a service from the container.
        /// </summary>
        /// <typeparam name="TService">The service type to resolve.</typeparam>
        /// <param name="instance">The resulting component instance providing the service, or default(TService).</param>
        /// <returns>True if a component providing the service is available.</returns>
        bool TryResolve<TService>(out TService instance) where TService : class;

        /// <summary>Try to retrieve a service from the container.
        /// </summary>
        /// <param name="serviceType">The service type to resolve.</param>
        /// <param name="instance">The resulting component instance providing the service, or null.</param>
        /// <returns>True if a component providing the service is available.</returns>
        bool TryResolve(Type serviceType, out object instance);

        /// <summary>Resolve a service.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <param name="serviceName">The service name.</param>
        /// <returns>The component instance that provides the service.</returns>
        TService ResolveNamed<TService>(string serviceName) where TService : class;

        /// <summary>Resolve a service.
        /// </summary>
        /// <param name="serviceName">The service name.</param>
        /// <param name="serviceType">The service type.</param>
        /// <returns>The component instance that provides the service.</returns>
        object ResolveNamed(string serviceName, Type serviceType);

        /// <summary>Try to retrieve a service from the container.
        /// </summary>
        /// <param name="serviceName">The name of the service to resolve.</param>
        /// <param name="serviceType">The type of the service to resolve.</param>
        /// <param name="instance">The resulting component instance providing the service, or null.</param>
        /// <returns>True if a component providing the service is available.</returns>
        bool TryResolveNamed(string serviceName, Type serviceType, out object instance);
    }
}