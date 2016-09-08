using LogMonitor.Infrastructure;
using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 9:42:43
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.Model
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public sealed class LogRecord : IAggregateRoot<long>
    {
        /// <summary>
        /// 主Id，自增
        /// </summary>
        public long FId { get; set; }

        /// <summary>
        /// 日志类型(枚举)
        /// </summary>
        public LogTypeEnum FLogType { get; set; }

        /// <summary>
        /// 程序名字
        /// </summary>
        public string FAppDomain { get; set; }

        /// <summary>
        /// 项目Id
        /// </summary>
        public int? FProjectId { get; set; }

        /// <summary>
        /// 项目代码
        /// </summary>
        public string FProjectCode { get; set; }

        /// <summary>
        /// 模块Id
        /// </summary>
        public int? FModuleId { get; set; }

        /// <summary>
        /// 模块代码
        /// </summary>
        public string FModuleCode { get; set; }

        /// <summary>
        /// 日志信息
        /// </summary>
        public string FMessage { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime FCreateTime { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime FAddTime { get; set; }
    }
}