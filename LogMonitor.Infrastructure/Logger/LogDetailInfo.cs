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
        public LogDetailInfo()
        {
        }

        public LogDetailInfo(LogTypeEnum logType, string module, string message) : base()
        {
            LogType = logType;
            BelongModule = module;
            Message = message;
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 日志类型
        /// </summary>
        public LogTypeEnum LogType { get; set; }

        /// <summary>
        /// 所属模块
        /// </summary>
        public string BelongModule { get; set; }

        /// <summary>
        /// 记录内容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        #region CreateLog

        /// <summary>
        /// 创建一个错误日志信息
        /// </summary>
        /// <param name="message">调试内容</param>
        /// <param name="belongModule">所属模块</param>
        /// <returns>日志信息</returns>
        public static LogDetailInfo CreateErrorLog(string message, string belongModule = null)
        {
            return new LogDetailInfo(LogTypeEnum.Error, belongModule, message);
        }

        /// <summary>
        /// 创建一个调试日志信息
        /// </summary>
        /// <param name="message">调试内容</param>
        /// <param name="belongModule">所属模块</param>
        /// <returns>日志信息</returns>
        public static LogDetailInfo CreateDebugLog(string message, string belongModule = null)
        {
            return new LogDetailInfo(LogTypeEnum.Debug, belongModule, message);
        }

        /// <summary>
        /// 创建一个警告日志信息
        /// </summary>
        /// <param name="message">警告内容</param>
        /// <param name="belongModule">所属模块</param>
        /// <returns>日志信息</returns>
        public static LogDetailInfo CreateWarningLog(string message, string belongModule = null)
        {
            return new LogDetailInfo(LogTypeEnum.Warning, belongModule, message);
        }

        /// <summary>
        /// 创建一个普通日志信息
        /// </summary>
        /// <param name="message">内容</param>
        /// <param name="belongModule">所属模块</param>
        /// <returns>日志信息</returns>
        public static LogDetailInfo CreateInfoLog(string message, string belongModule = null)
        {
            return new LogDetailInfo(LogTypeEnum.Info, belongModule, message);
        }

        /// <summary>
        /// 创建一个严重日志信息
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="belongModule">所属模块</param>
        /// <returns>日志信息</returns>
        public static LogDetailInfo CreateFatalLog(string message, string belongModule = null)
        {
            return new LogDetailInfo(LogTypeEnum.Fatal, belongModule, message);
        }

        #endregion CreateLog
    }
}