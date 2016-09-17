using LogMonitor.Domain.Model;
using LogMonitor.IDomianService;
using LogMonitor.Infrastructure;
using LogMonitor.IRepository;
using System;
using System.Linq;
using LogMonitor.Infrastructure.Extension;
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
                LogRecord logRecord = new LogRecord()
                {
                    FCreateTime = Convert.ToDateTime(details[0]),
                    FAppDomain = details[1],
                    FProjectCode = details[3],
                    FMessage = details[4],
                    FAddTime = DateTime.Now,
                    FIsNoticed = false,
                    FLogType = details[2].ToLogType()
                };
                //查找并设置模块信息
                SearchAndSetModuleInfo(logRecord);
                //查找项目信息
                SearchAndSetProjectInfo(logRecord);
                ////获取管理员列表
                var adminList = _userRepository.GetAdminList().ToList();
                if (adminList != null && adminList.Count > 0)
                {
                    logRecord.AddCharges(adminList);
                }

                return logRecord;
            }
            return null;
        }

        #endregion 根据传输的日志内容获取日志记录对象

        #region 查找并设置模块信息

        /// <summary>
        /// 查找并设置模块信息
        /// </summary>
        /// <param name="logRecord">日志记录</param>
        /// <returns>日志记录</returns>
        public LogRecord SearchAndSetModuleInfo(LogRecord logRecord)
        {
            if (!string.IsNullOrWhiteSpace(logRecord.FModuleCode) && !string.IsNullOrWhiteSpace(logRecord.FProjectCode))
            {
                ProjectModule projectModule = _projectModuleRepository.GetProjectModule(logRecord.FModuleCode, logRecord.FProjectCode);
                if (projectModule != null)
                {
                    logRecord.SetModuleInfo(projectModule);
                }
            }
            return logRecord;
        }

        #endregion 查找并设置模块信息

        #region 查找并设置项目信息

        /// <summary>
        /// 查找并设置项目信息
        /// </summary>
        /// <param name="logRecord">日志记录</param>
        /// <returns>日志记录</returns>
        public LogRecord SearchAndSetProjectInfo(LogRecord logRecord)
        {
            if (!string.IsNullOrWhiteSpace(logRecord.FProjectCode))
            {
                Project project = _projectRepository.GetProjectInfo(logRecord.FProjectCode);
                if (project != null)
                {
                    logRecord.SetProjectInfo(project);
                }
            }
            return logRecord;
        }

        #endregion 查找并设置项目信息
    }
}