using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 10:55:30
* Class Version       :    v1.0.0.0
* Class Description   :    创建日志输出类
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public interface ILoggerFactory
    {
        /// <summary>Create a logger with the given logger name.
        /// </summary>
        ILogger Create(string name);

        /// <summary>Create a logger with the given type.
        /// </summary>
        ILogger Create(Type type);
    }
}