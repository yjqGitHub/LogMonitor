using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Integration.Mvc;
using System;
using System.Reflection;
using System.Web;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 11:45:53
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public sealed class AutofacObjectContainer : IObjectContainer
    {
        private readonly IContainer _container;

        #region .ctor

        public AutofacObjectContainer()
        {
            _container = new ContainerBuilder().Build();
        }

        public AutofacObjectContainer(ContainerBuilder containerBuilder)
        {
            _container = containerBuilder.Build();
        }

        #endregion .ctor

        public IContainer Container { get { return _container; } }

        #region Register

        /// <summary>
        /// 注册一个实例
        /// </summary>
        /// <param name="implementationType">实例类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="life">实例存活周期</param>
        public void RegisterType(Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton)
        {
            var builder = new ContainerBuilder();
            var registrationBuilder = builder.RegisterType(implementationType);
            if (serviceName != null)
            {
                registrationBuilder.Named(serviceName, implementationType);
            }
            switch (life)
            {
                case LifeStyle.Singleton:
                    registrationBuilder.SingleInstance();
                    break;

                case LifeStyle.PerLifetimeScope:
                    registrationBuilder.InstancePerLifetimeScope();
                    break;

                case LifeStyle.RequestLifetimeScope:
                    registrationBuilder.InstancePerRequest();
                    break;

                default:
                    break;
            }
            builder.Update(_container);
        }

        /// <summary>
        /// 注册一个实例
        /// </summary>
        /// <param name="serviceType">接口</param>
        /// <param name="implementationType">实例类型</param>
        /// <param name="serviceName">服务名字</param>
        /// <param name="life">存活周期</param>
        public void RegisterType(Type serviceType, Type implementationType, string serviceName = null, LifeStyle life = LifeStyle.Singleton)
        {
            var builder = new ContainerBuilder();
            var registrationBuilder = builder.RegisterType(implementationType).As(serviceType);
            if (serviceName != null)
            {
                registrationBuilder.Named(serviceName, serviceType);
            }
            switch (life)
            {
                case LifeStyle.Singleton:
                    registrationBuilder.SingleInstance();
                    break;

                case LifeStyle.PerLifetimeScope:
                    registrationBuilder.InstancePerLifetimeScope();
                    break;

                case LifeStyle.RequestLifetimeScope:
                    registrationBuilder.InstancePerRequest();
                    break;

                default:
                    break;
            }
            builder.Update(_container);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">接口类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="serviceName">服务名字</param>
        /// <param name="life">存活周期</param>
        public void Register<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            var builder = new ContainerBuilder();
            var registrationBuilder = builder.RegisterType<TImplementer>().As<TService>();
            if (serviceName != null)
            {
                registrationBuilder.Named<TService>(serviceName);
            }
            switch (life)
            {
                case LifeStyle.Singleton:
                    registrationBuilder.SingleInstance();
                    break;

                case LifeStyle.PerLifetimeScope:
                    registrationBuilder.InstancePerLifetimeScope();
                    break;

                case LifeStyle.RequestLifetimeScope:
                    registrationBuilder.InstancePerRequest();
                    break;

                default:
                    break;
            }

            builder.Update(_container);
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <typeparam name="TService">接口类型</typeparam>
        /// <typeparam name="TImplementer">实例类型</typeparam>
        /// <param name="instance">实例</param>
        /// <param name="serviceName">服务名字</param>
        public void RegisterInstance<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService
        {
            var builder = new ContainerBuilder();
            var registrationBuilder = builder.RegisterInstance(instance).As<TService>().SingleInstance();
            if (serviceName != null)
            {
                registrationBuilder.Named<TService>(serviceName);
            }
            builder.Update(_container);
        }

        /// <summary>
        /// 根据程序集去注册
        /// </summary>
        /// <param name="predicate">删选程序集</param>
        /// <param name="assemblies">程序集</param>
        /// <param name="life">注册实例存活周期</param>
        public void RegisterAssemblyTypes(Assembly assemblies, Func<Type, bool> predicate = null, LifeStyle life = LifeStyle.PerLifetimeScope)
        {
            if (assemblies != null)
            {
                var builder = new ContainerBuilder();
                var registrationBuilder = builder.RegisterAssemblyTypes(assemblies);
                if (predicate != null)
                {
                    registrationBuilder.Where(predicate);
                }
                switch (life)
                {
                    case LifeStyle.Singleton:
                        registrationBuilder.AsImplementedInterfaces().SingleInstance();
                        break;

                    case LifeStyle.PerLifetimeScope:
                        registrationBuilder.AsImplementedInterfaces().InstancePerLifetimeScope();
                        break;

                    case LifeStyle.RequestLifetimeScope:
                        registrationBuilder.InstancePerRequest();
                        break;

                    default:
                        registrationBuilder.AsImplementedInterfaces();
                        break;
                }
                builder.Update(_container);
            }
        }

        #endregion Register

        #region Resolve

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <returns>注册的服务类型</returns>
        public TService Resolve<TService>() where TService : class
        {
            return Scope().Resolve<TService>();
        }

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <returns>注册的服务类型</returns>
        public object Resolve(Type serviceType)
        {
            return Scope().Resolve(serviceType);
        }

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="instance">服务类型默认实例</param>
        /// <returns>成功 则返回true</returns>
        public bool TryResolve<TService>(out TService instance) where TService : class
        {
            return Scope().TryResolve(out instance);
        }

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="instance"></param>
        /// <returns>成功 则返回true</returns>
        public bool TryResolve(Type serviceType, out object instance)
        {
            return Scope().TryResolve(serviceType, out instance);
        }

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="serviceName">服务名字</param>
        /// <returns>服务类型</returns>
        public TService ResolveNamed<TService>(string serviceName) where TService : class
        {
            return Scope().ResolveNamed<TService>(serviceName);
        }

        /// <summary>
        /// 取出注册的服务类型
        /// </summary>
        /// <param name="serviceName">服务名字</param>
        /// <param name="serviceType">服务类型</param>
        /// <returns>服务类型</returns>
        public object ResolveNamed(string serviceName, Type serviceType)
        {
            return Scope().ResolveNamed(serviceName, serviceType);
        }

        /// <summary>
        /// 尝试取出注册的服务类型
        /// </summary>
        /// <param name="serviceName">服务名字</param>
        /// <param name="serviceType">服务类型</param>
        /// <param name="instance">默认实例</param>
        /// <returns>成功 则返回true</returns>
        public bool TryResolveNamed(string serviceName, Type serviceType, out object instance)
        {
            return Scope().TryResolveNamed(serviceName, serviceType, out instance);
        }

        #endregion Resolve

        public ILifetimeScope Scope()
        {
            try
            {
                if (HttpContext.Current != null)
                    return AutofacDependencyResolver.Current.RequestLifetimeScope;

                //when such lifetime scope is returned, you should be sure that it'll be disposed once used (e.g. in schedule tasks)
                return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
            catch
            {
                //we can get an exception here if RequestLifetimeScope is already disposed
                //for example, requested in or after "Application_EndRequest" handler
                //but note that usually it should never happen

                //when such lifetime scope is returned, you should be sure that it'll be disposed once used (e.g. in schedule tasks)
                return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
        }
    }
}