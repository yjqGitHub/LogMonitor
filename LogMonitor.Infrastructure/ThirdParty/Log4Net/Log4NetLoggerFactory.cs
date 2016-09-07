using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using System;
using System.IO;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 10:31:05
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public sealed class Log4NetLoggerFactory : ILoggerFactory
    {
        public Log4NetLoggerFactory(string configFilePath)
        {
            var file = new FileInfo(Path.Combine(PathHelper.GetMapPath(), configFilePath));
            if (!file.Exists)
            {
                file = new FileInfo(configFilePath);
            }
            if (file.Exists)
            {
                XmlConfigurator.ConfigureAndWatch(file);
            }
            else
            {
                BasicConfigurator.Configure(new ConsoleAppender { Layout = new PatternLayout() });
            }
        }

        /// <summary>
        /// 根据名字创建 Log4NetLogger 实例.
        /// </summary>
        /// <param name="name">名字</param>
        /// <returns>Log4NetLogger 实例</returns>
        public ILogger Create(string name)
        {
            return new Log4NetLogger(LogManager.GetLogger(name));
        }

        /// <summary>
        /// 根据类型创建 Log4NetLogger 实例.
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>Log4NetLogger 实例</returns>
        public ILogger Create(Type type)
        {
            return new Log4NetLogger(LogManager.GetLogger(type));
        }
    }
}