using LogMonitor.Infrastructure;
using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 15:48:26
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.Model
{
    /// <summary>
    /// 错误记录
    /// </summary>
    public sealed class ErrorLogRecord : IAggregateRoot<long>
    {
        /// <summary>
        /// 主键、自增
        /// </summary>
        public long FId { get; set; }

        /// <summary>
        /// 程序名字
        /// </summary>
        public string FAppDomain { get; set; }

        /// <summary>
        /// 项目代码
        /// </summary>
        public string FProjectCode { get; set; }

        /// <summary>
        /// 日志类型(枚举)
        /// </summary>
        public LogTypeEnum FLogType { get; set; }

        /// <summary>
        /// 执行的类名
        /// </summary>
        public string FClassName { get; set; }

        /// <summary>
        /// 执行的方法
        /// </summary>
        public string FMethodName { get; set; }

        /// <summary>
        /// 请求的方法类型
        /// </summary>
        public string FRequestType { get; set; }

        /// <summary>
        /// 请求的地址
        /// </summary>
        public string FQueryUrl { get; set; }

        /// <summary>
        /// 请求的Ip
        /// </summary>
        public string FRequestIp { get; set; }

        /// <summary>
        /// Ip对应的地址
        /// </summary>
        public string FIpAddress { get; set; }

        /// <summary>
        /// 客户端信息
        /// </summary>
        public string FUserAgent { get; set; }

        /// <summary>
        /// 请求时间
        /// </summary>
        public DateTime FRequestTime { get; set; }

        /// <summary>
        /// 日志信息
        /// </summary>
        public string FLogMessage { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime FAddTime { get; set; }
    }
}