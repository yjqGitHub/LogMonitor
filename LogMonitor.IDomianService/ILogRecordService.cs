using LogMonitor.Domain.Model;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 13:56:38
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.IDomianService
{
    public interface ILogRecordService
    {
        #region 根据传输的日志内容获取日志记录对象

        /// <summary>
        /// 根据传输的日志内容获取日志记录对象
        /// </summary>
        /// <param name="logInfo">传输的日志内容</param>
        /// <returns>日志记录对象</returns>
        LogRecord CreateLogRecord(string logInfo);

        #endregion 根据传输的日志内容获取日志记录对象

        #region 查找并设置模块信息

        /// <summary>
        /// 查找并设置模块信息
        /// </summary>
        /// <param name="logRecord">日志记录</param>
        /// <returns>日志记录</returns>
        LogRecord SearchAndSetModuleInfo(LogRecord logRecord);

        #endregion 查找并设置模块信息

        #region 查找并设置项目信息

        /// <summary>
        /// 查找并设置项目信息
        /// </summary>
        /// <param name="logRecord">日志记录</param>
        /// <returns>日志记录</returns>
        LogRecord SearchAndSetProjectInfo(LogRecord logRecord);

        #endregion 查找并设置项目信息
    }
}