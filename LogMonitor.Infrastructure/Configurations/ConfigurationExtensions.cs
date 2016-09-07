using Autofac;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 14:24:47
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure.Configurations
{
    public static class ConfigurationExtensions
    {
        #region 使用autofac为依赖注入控件

        /// <summary>
        /// 使用autofac为依赖注入控件
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static Configuration UseAutofac(this Configuration configuration)
        {
            return UseAutofac(configuration, new ContainerBuilder());
        }

        /// <summary>
        /// 使用autofac为依赖注入控件
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="containerBuilder"></param>
        /// <returns></returns>
        public static Configuration UseAutofac(this Configuration configuration, ContainerBuilder containerBuilder)
        {
            ObjectContainer.SetContainer(new AutofacObjectContainer(containerBuilder));
            return configuration;
        }

        #endregion 使用autofac为依赖注入控件

        #region 使用log4net为记录日志文件

        /// <summary>
        /// 使用log4net为记录日志文件
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static Configuration UseLog4Net(this Configuration configuration)
        {
            return UseLog4Net(configuration, SysContant.Path_Log4NetConfig);
        }

        /// <summary>
        /// 使用log4net为记录日志文件
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="configFile">文件相对路径或绝对路径</param>
        /// <returns></returns>
        public static Configuration UseLog4Net(this Configuration configuration, string configFile)
        {
            configuration.SetDefault<ILoggerFactory, Log4NetLoggerFactory>(new Log4NetLoggerFactory(configFile));
            return configuration;
        }

        #endregion 使用log4net为记录日志文件

        #region 使用jsonNet来序列化

        /// <summary>
        /// 使用jsonNet来序列化
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static Configuration UseJsonNet(this Configuration configuration)
        {
            configuration.SetDefault<IJsonSerializer, NewtonsoftJsonSerializer>(new NewtonsoftJsonSerializer());
            return configuration;
        }

        #endregion 使用jsonNet来序列化
    }
}