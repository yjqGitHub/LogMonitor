using LogMonitor.Domain.Model;
using LogMonitor.IDomianService;
using LogMonitor.Infrastructure;
using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 13:58:00
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.DomainService
{
    public sealed class LogRecordService : ILogRecordService
    {
        private readonly IJsonSerializer _jsonSerializer;

        public LogRecordService()
        {
            _jsonSerializer = ObjectContainer.Current.Resolve<IJsonSerializer>();
        }

        #region 根据传输的日志内容获取日志记录对象

        /// <summary>
        /// 根据传输的日志内容获取日志记录对象
        /// </summary>
        /// <param name="logInfo">传输的日志内容</param>
        /// <returns>日志记录对象</returns>
        public LogRecord CreateLogRecord(string logInfo)
        {
            Ensure.NotNullOrEmpty(logInfo, "logInfo");
            //%d$$%a$$%-5p$$%c$$%m%n  日期$$项目$$日志等级$$logerName$$内容
            string[] details = logInfo.Split(new string[] { "$$" }, StringSplitOptions.None);
            if (details.Length >= 5)
            {
                LogDetailInfo logDetailInfo = _jsonSerializer.Deserialize<LogDetailInfo>(details[4]);
                LogRecord logRecord = new LogRecord()
                {
                    FCreateTime = logDetailInfo.CreateTime,
                    FAddTime = DateTime.Now,
                    FAppDomain = details[1],
                    FProjectCode = details[3],
                    FLogType = logDetailInfo.LogType,
                    FMessage = logDetailInfo.Message,
                    FModuleCode = logDetailInfo.BelongModule
                };
                return logRecord;
            }
            return null;
        }

        #endregion 根据传输的日志内容获取日志记录对象
    }
}