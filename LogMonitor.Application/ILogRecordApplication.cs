/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 14:27:49
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

using System.Runtime.CompilerServices;

namespace LogMonitor.Application
{
    public interface ILogRecordApplication
    {
        #region 添加一条日志记录

        /// <summary>
        /// 添加一条日志记录
        /// </summary>
        /// <param name="logDetail"></param>
        /// <returns></returns>
        bool AddLogRecord(string logDetail, [CallerMemberName] string memberName = null, string defaultLoggerName = null);

        #endregion 添加一条日志记录
    }
}