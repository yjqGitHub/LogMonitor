using Autofac;
using Autofac.Integration.Mvc;
using LogMonitor.Infrastructure;
using LogMonitor.Infrastructure.Configurations;
using LogMonitor.IUnitOfWork;
using LogMonitor.Repository.DbManage;
using LogMonitor.Repository.UnitOfWork;
using System.Reflection;
using System.Web.Mvc;
using LogMonitorConfiguration = LogMonitor.Infrastructure.Configurations.Configuration;

namespace LogMonitor.WebManage.App_Start
{
    public sealed class Bootstrapper
    {
        public static void Install()
        {
            var repository = Assembly.Load("LogMonitor.Repository");
            var domainService = Assembly.Load("LogMonitor.DomainService");
            var application = Assembly.Load("LogMonitor.Application");
            var damianEvent = Assembly.Load("LogMonitor.Domain.DomainEvent");
            LogMonitorConfiguration.Create()
                                   .UseAutofac()
                                   .UseJsonNet()
                                   .UseLog4Net()
                                   .SetDefault<IDbFactory, DbFactory>(life: LifeStyle.RequestLifetimeScope)
                                   .SetDefault<ILogMonitorUnitOfWork, LogMonitorUnitOfWork>(life: LifeStyle.RequestLifetimeScope)
                                   .RegisterAssemblyTypes(repository, m => m.Namespace != null && m.Namespace.StartsWith("LogMonitor.Repository.Repository"), LifeStyle.RequestLifetimeScope)
                                   .RegisterAssemblyTypes(domainService, m => m.Namespace != null && m.Namespace.StartsWith("LogMonitor.DomainService"), LifeStyle.RequestLifetimeScope)
                                   .RegisterAssemblyTypes(application, m => m.Namespace != null && m.Namespace.StartsWith("LogMonitor.Application.Implemenet"), LifeStyle.RequestLifetimeScope)
                                   .RegisterAssemblyTypes(damianEvent, m => m.Namespace != null && m.Namespace.StartsWith("LogMonitor.Domain.DomainEvent"), LifeStyle.RequestLifetimeScope)
                                   ;
            RegisterControllers();
        }

        private static void RegisterControllers()
        {
            var container = (ObjectContainer.Current as AutofacObjectContainer).Container;
            var builder = new ContainerBuilder();
            //注册控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.Update(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}