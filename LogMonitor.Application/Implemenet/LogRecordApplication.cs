using LogMonitor.Domain.Model;
using LogMonitor.IDomianService;
using LogMonitor.Infrastructure;
using LogMonitor.IRepository;
using LogMonitor.IUnitOfWork;
using System.Runtime.CompilerServices;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 14:29:18
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Application.Implemenet
{
    public sealed class LogRecordApplication : ILogRecordApplication
    {
        private readonly ILogRecordService _logRecordService;
        private readonly ILogRecordRepository _logRecordRepository;
        private readonly ILogMonitorUnitOfWork _logMonitorUnitOfWork;

        public LogRecordApplication(ILogRecordService logRecordService, ILogRecordRepository logRecordRepository, ILogMonitorUnitOfWork logMonitorUnitOfWork)
        {
            _logRecordService = logRecordService;
            _logRecordRepository = logRecordRepository;
            _logMonitorUnitOfWork = logMonitorUnitOfWork;
        }

        #region 添加一条日志记录

        /// <summary>
        /// 添加一条日志记录
        /// </summary>
        /// <param name="logDetail"></param>
        /// <returns></returns>
        public bool AddLogRecord(string logDetail, [CallerMemberName] string memberName = null, string defaultLoggerName = null)
        {
            return ExceptionHelper.IgnoreButLogException<bool>(() =>
            {
                LogRecord logRecord = _logRecordService.CreateLogRecord(logDetail);
                if (logRecord != null)
                {
                    _logRecordRepository.Add(logRecord);
                    return _logMonitorUnitOfWork.Commit();
                }
                return false;
            }, defaultValue: false, memberName: memberName, defaultLoggerName: defaultLoggerName);
        }

        #endregion 添加一条日志记录
    }
}