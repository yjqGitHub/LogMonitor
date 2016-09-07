using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 20:27:22
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    /// <summary>
    /// 记录详情
    /// </summary>
    public sealed class LogDetailInfo
    {
        /// <summary>
        /// 日志类型
        /// </summary>
        public LogTypeEnum LogType { get; set; }

        /// <summary>
        /// 调用名字
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// 调用方法
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// 请求的地址
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// 请求的客户端信息
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 请求的Ip
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 请求的方式
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 记录内容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 执行所花的时间(毫秒)
        /// </summary>
        public double ExecuteMillseconds { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}