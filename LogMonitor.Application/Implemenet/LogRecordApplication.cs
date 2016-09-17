using LogMonitor.Domain.Model;
using LogMonitor.IDomianService;
using LogMonitor.Infrastructure;
using LogMonitor.IRepository;
using LogMonitor.IUnitOfWork;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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
        /// <param name="logDetail">日志内容</param>
        /// <param name="memberName">调用的方法名字</param>
        /// <param name="defaultLoggerName">默认日志记录器</param>
        /// <returns>true标识添加成功</returns>
        public async Task<bool> AddLogRecordAsync(string logDetail, [CallerMemberName] string memberName = null, string defaultLoggerName = null)
        {
            return await ExceptionHelper.IgnoreButLogExceptionAsync<bool>(async () =>
           {
               LogRecord logRecord = _logRecordService.CreateLogRecord(logDetail);
               if (logRecord != null)
               {
                   _logRecordRepository.Add(logRecord);
                   Task haveNewRecordTask = logRecord.HaveNewRecordAsync();
                   return await _logMonitorUnitOfWork.CommitAsync();
               }
               return false;
           }, defaultValue: false, memberName: memberName, defaultLoggerName: defaultLoggerName);
        }

        /// <summary>
        /// 添加一条日志记录
        /// </summary>
        /// <param name="logDetail">日志内容</param>
        /// <param name="memberName">调用的方法名字</param>
        /// <param name="defaultLoggerName">默认日志记录器</param>
        /// <returns>true标识添加成功</returns>
        public bool AddLogRecord(string logDetail, [CallerMemberName] string memberName = null, string defaultLoggerName = null)
        {
            return ExceptionHelper.IgnoreButLogException<bool>(() =>
          {
              LogRecord logRecord = _logRecordService.CreateLogRecord(logDetail);
              if (logRecord != null)
              {
                  _logRecordRepository.Add(logRecord);
                  Task haveNewRecordTask = logRecord.HaveNewRecordAsync();
                  return _logMonitorUnitOfWork.Commit();
              }
              return false;
          }, defaultValue: false, memberName: memberName, defaultLoggerName: defaultLoggerName);
        }

        #endregion 添加一条日志记录
    }
}