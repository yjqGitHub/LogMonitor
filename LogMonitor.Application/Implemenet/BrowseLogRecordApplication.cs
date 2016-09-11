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
* Create Time         :    2016/9/11 17:10:05
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Application.Implemenet
{
    public sealed class BrowseLogRecordApplication : IBrowseLogRecordApplication
    {
        private readonly IBrowseLogRecordDomainService _browseLogRecordDomainService;
        private readonly IBrowseLogRecordRepository _browseLogRecordRepository;
        private readonly ILogMonitorUnitOfWork _logMonitorUnitOfWork;

        public BrowseLogRecordApplication(IBrowseLogRecordDomainService browseLogRecordDomainService, IBrowseLogRecordRepository browseLogRecordRepository, ILogMonitorUnitOfWork logMonitorUnitOfWork)
        {
            _browseLogRecordDomainService = browseLogRecordDomainService;
            _browseLogRecordRepository = browseLogRecordRepository;
            _logMonitorUnitOfWork = logMonitorUnitOfWork;
        }

        #region 添加一条浏览记录

        /// <summary>
        /// 添加一条浏览记录
        /// </summary>
        /// <param name="logDetail">日志内容</param>
        /// <param name="memberName">调用的方法名字</param>
        /// <param name="defaultLoggerName">默认日志记录器</param>
        /// <returns>true标识添加成功</returns>
        public bool AddBrowseLog(string logDetail, [CallerMemberName] string memberName = null, string defaultLoggerName = null)
        {
            return ExceptionHelper.IgnoreButLogException<bool>(() =>
            {
                BrowseLogRecord browseLogRecord = _browseLogRecordDomainService.CreateBrowseLogRecord(logDetail);
                if (browseLogRecord != null)
                {
                    _browseLogRecordRepository.Add(browseLogRecord);
                    return _logMonitorUnitOfWork.Commit();
                }
                return false;
            }, defaultValue: false, memberName: memberName, defaultLoggerName: defaultLoggerName);
        }

        #endregion 添加一条浏览记录

        #region 异步添加一条浏览记录

        /// <summary>
        /// 异步添加一条浏览记录
        /// </summary>
        /// <param name="logDetail">日志内容</param>
        /// <param name="memberName">调用的方法名字</param>
        /// <param name="defaultLoggerName">默认日志记录器</param>
        /// <returns>true标识添加成功</returns>
        public async Task<bool> AddBrowseLogAsync(string logDetail, [CallerMemberName] string memberName = null, string defaultLoggerName = null)
        {
            return await ExceptionHelper.IgnoreButLogExceptionAsync<bool>(async () =>
            {
                BrowseLogRecord browseLogRecord = _browseLogRecordDomainService.CreateBrowseLogRecord(logDetail);
                if (browseLogRecord != null)
                {
                    _browseLogRecordRepository.Add(browseLogRecord);
                    return await _logMonitorUnitOfWork.CommitAsync();
                }
                return false;
            }, defaultValue: false, memberName: memberName, defaultLoggerName: defaultLoggerName);
        }

        #endregion 异步添加一条浏览记录
    }
}