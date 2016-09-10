using LogMonitor.Domain.Model;
using LogMonitor.Domain.ValueObject;
using LogMonitor.IDomianService;
using LogMonitor.Infrastructure;
using LogMonitor.IRepository;
using System;
using System.Linq;

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
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectModuleRepository _projectModuleRepository;
        private readonly IUserRepository _userRepository;

        public LogRecordService(IProjectRepository projectRepository, IProjectModuleRepository projectModuleRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _projectModuleRepository = projectModuleRepository;
            _userRepository = userRepository;
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

                //查找模块信息
                if (!string.IsNullOrWhiteSpace(logRecord.FModuleCode))
                {
                    ProjectModule projectModule = _projectModuleRepository.GetProjectModule(logRecord.FModuleCode, logRecord.FProjectCode);
                    if (projectModule != null)
                    {
                        logRecord.SetModuleInfo(projectModule);
                    }
                }
                //查找项目信息
                if (!string.IsNullOrWhiteSpace(logRecord.FProjectCode))
                {
                    Project project = _projectRepository.GetProjectInfo(logRecord.FProjectCode);
                    if (project != null)
                    {
                        logRecord.SetProjectInfo(project);
                    }
                }
                //获取管理员列表
                var adminList = _userRepository.GetAdminList();
                if (adminList != null && adminList.Count() > 0)
                {
                    logRecord.AddCharges(adminList.Select(m => new MemberInfo()
                    {
                        IsManager = true,
                        MemberEmail = m.FEmail,
                        MemberId = m.FId,
                        MemberMobile = m.FMobile,
                        MemberName = m.FName
                    }).ToList());
                }

                return logRecord;
            }
            return null;
        }

        #endregion 根据传输的日志内容获取日志记录对象
    }
}