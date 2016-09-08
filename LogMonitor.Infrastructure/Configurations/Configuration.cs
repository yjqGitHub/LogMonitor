/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 14:23:53
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

using System;
using System.Reflection;

namespace LogMonitor.Infrastructure.Configurations
{
    public sealed class Configuration
    {
        public static Configuration Instance { get; private set; }

        private Configuration()
        {
        }

        public static Configuration Create()
        {
            Instance = new Configuration();
            return Instance;
        }

        public Configuration SetDefault<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            ObjectContainer.Register<TService, TImplementer>(serviceName, life);
            return this;
        }

        public Configuration SetDefault<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService
        {
            ObjectContainer.RegisterInstance<TService, TImplementer>(instance, serviceName);
            return this;
        }

        public Configuration RegisterAssemblyTypes(Assembly assemblies, Func<Type, bool> predicate = null)
        {
            ObjectContainer.RegisterAssemblyTypes(assemblies, predicate);
            return this;
        }
    }
}