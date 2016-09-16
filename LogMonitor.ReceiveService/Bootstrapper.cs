using LogMonitor.Infrastructure;
using LogMonitor.Infrastructure.Configurations;
using LogMonitor.Infrastructure.Extension;
using LogMonitor.IUnitOfWork;
using LogMonitor.Repository.DbManage;
using LogMonitor.Repository.UnitOfWork;
using System;
using System.Reflection;
using LogMonitorConfiguration = LogMonitor.Infrastructure.Configurations.Configuration;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 16:21:20
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.ReceiveService
{
    public sealed class Bootstrapper
    {
        public static void Install()
        {
            var repository = Assembly.Load("LogMonitor.Repository");
            var domainService = Assembly.Load("LogMonitor.DomainService");
            var application = Assembly.Load("LogMonitor.Application");
            var damianEvent= Assembly.Load("LogMonitor.Domain.DomainEvent");
            LogMonitorConfiguration.Create()
                                   .UseAutofac()
                                   .UseJsonNet()
                                   .UseLog4Net()
                                   .SetDefault<IDbFactory, DbFactory>(life:LifeStyle.PerLifetimeScope)
                                   .SetDefault<ILogMonitorUnitOfWork, LogMonitorUnitOfWork>(life: LifeStyle.Transient)
                                   .RegisterAssemblyTypes(repository, m => m.Namespace != null && m.Namespace.StartsWith("LogMonitor.Repository.Repository"),LifeStyle.Transient)
                                   .RegisterAssemblyTypes(domainService, m => m.Namespace != null && m.Namespace.StartsWith("LogMonitor.DomainService"), LifeStyle.Transient)
                                   .RegisterAssemblyTypes(application, m => m.Namespace != null && m.Namespace.StartsWith("LogMonitor.Application.Implemenet"))
                                   .RegisterAssemblyTypes(damianEvent,m=>m.Namespace!=null&&m.Namespace.StartsWith("LogMonitor.Domain.DomainEvent"), LifeStyle.Transient)
                                   ;

            var logger = ObjectContainer.Current.Resolve<ILoggerFactory>().Create(SysContant.LoggerName_Default);
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Exception ex = e.ExceptionObject as Exception;
                if (ex != null)
                {
                    string errorMessage = ExceptionHelper.GetJsonErrorLog(ex, belongModule: SysContant.Module_ReceiveService);
                    logger.Error(errorMessage);
                }
                else
                {
                    LogDetailInfo logDetailInfo = LogDetailInfo.CreateErrorLog(string.Format("Unhandled exception: {0}", e.ExceptionObject), SysContant.Module_ReceiveService);
                    logger.Error(logDetailInfo.ToJson());
                }
            };
        }
    }
}