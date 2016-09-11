using System;

// ===============================================================================
// Author              :    yjq
// Email               :    425527169@qq.com
// Create Time         :    2016/9/11 15:45:59
// ===============================================================================
// Class Version       :    v1.0.0.0
// Class Description   :
// ===============================================================================
// Copyright ©yjq 2016 . All rights reserved.
// ===============================================================================
namespace LogMonitor.Infrastructure
{
    public sealed class BrowseLogRecordDetailInfo
    {
        /// <summary>
        /// 请求的方法类型
        /// </summary>
        public string RequestType { get; set; }

        /// <summary>
        /// 请求的绝对地址
        /// </summary>
        public string AbsoluteUrl { get; set; }

        /// <summary>
        /// 请求的地址
        /// </summary>
        public string QueryUrl { get; set; }

        /// <summary>
        /// 请求的Ip
        /// </summary>
        public string RequestIp { get; set; }

        /// <summary>
        /// 客户端信息
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 请求时间
        /// </summary>
        public DateTime RequestTime { get; set; }

        /// <summary>
        /// 日志信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 执行消耗的时间
        /// </summary>
        public double ExecuteMillseconds { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}