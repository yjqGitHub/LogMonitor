/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 14:27:49
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LogMonitor.Application
{
    public interface ILogRecordApplication
    {
        #region 添加一条日志记录

        /// <summary>
        /// 添加一条日志记录
        /// </summary>
        /// <param name="logDetail">日志内容</param>
        /// <param name="memberName">调用的方法名字</param>
        /// <param name="defaultLoggerName">默认日志记录器</param>
        /// <returns>true标识添加成功</returns>
        Task<bool> AddLogRecordAsync(string logDetail, [CallerMemberName] string memberName = null, string defaultLoggerName = null);

        /// <summary>
        /// 添加一条日志记录
        /// </summary>
        /// <param name="logDetail">日志内容</param>
        /// <param name="memberName">调用的方法名字</param>
        /// <param name="defaultLoggerName">默认日志记录器</param>
        /// <returns>true标识添加成功</returns>
        bool AddLogRecord(string logDetail, [CallerMemberName] string memberName = null, string defaultLoggerName = null);

        #endregion 添加一条日志记录
    }
}