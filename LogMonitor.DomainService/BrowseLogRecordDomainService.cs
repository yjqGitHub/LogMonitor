using LogMonitor.Domain.Model;
using LogMonitor.IDomianService;
using LogMonitor.Infrastructure;
using LogMonitor.Infrastructure.Extension;
using LogMonitor.IRepository;
using System;

// ===============================================================================
// Author              :    yjq
// Email               :    425527169@qq.com
// Create Time         :    2016/9/11 10:37:29
// ===============================================================================
// Class Version       :    v1.0.0.0
// Class Description   :
// ===============================================================================
// Copyright ©yjq 2016 . All rights reserved.
// ===============================================================================
namespace LogMonitor.DomainService
{
    public sealed class BrowseLogRecordDomainService : IBrowseLogRecordDomainService
    {
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IBrowseLogRecordRepository _browseLogRecordRepository;

        public BrowseLogRecordDomainService(IBrowseLogRecordRepository browseLogRecordRepository)
        {
            _browseLogRecordRepository = browseLogRecordRepository;
            _jsonSerializer = ObjectContainer.Current.Resolve<IJsonSerializer>();
        }

        #region 根据传输的日志内容获取浏览记录对象

        /// <summary>
        /// 根据传输的日志内容获取浏览记录对象
        /// </summary>
        /// <param name="logDeatis">传输的日志内容</param>
        /// <returns>浏览记录对象</returns>
        public BrowseLogRecord CreateBrowseLogRecord(string logDeatis)
        {
            Ensure.NotNullOrEmpty(logDeatis, "logInfo");
            //%a$$%-5p$$%c$$%m%n  项目$$日志等级$$logerName$$内容
            string[] details = logDeatis.Split(new string[] { "$$" }, StringSplitOptions.None);
            if (details.Length >= 4)
            {
                BrowseLogRecordDetailInfo browseLogRecordDetailInfo = _jsonSerializer.Deserialize<BrowseLogRecordDetailInfo>(details[3]);
                BrowseLogRecord browseLogRecord = new BrowseLogRecord()
                {
                    FAppDomain = details[0],
                    FAbsoluteUrl = browseLogRecordDetailInfo.AbsoluteUrl,
                    FAddTime = DateTime.Now,
                    FExecuteMillseconds = browseLogRecordDetailInfo.ExecuteMillseconds,
                    FRequestIp = browseLogRecordDetailInfo.RequestIp,
                    FMessage = browseLogRecordDetailInfo.Message,
                    FProjectCode = details[2],
                    FQueryUrl = browseLogRecordDetailInfo.QueryUrl,
                    FRequestTime = browseLogRecordDetailInfo.AddTime,
                    FRequestType = browseLogRecordDetailInfo.RequestType,
                    FUserAgent = browseLogRecordDetailInfo.UserAgent,
                    IsLooked = false,
                    FIpAddress = browseLogRecordDetailInfo.RequestIp.SearchLocation()
                };
                return browseLogRecord;
            }
            return null;
        }

        #endregion 根据传输的日志内容获取浏览记录对象
    }
}