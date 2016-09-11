using LogMonitor.Domain.Model;

// ===============================================================================
// Author              :    yjq
// Email               :    425527169@qq.com
// Create Time         :    2016/9/11 10:35:35
// ===============================================================================
// Class Version       :    v1.0.0.0
// Class Description   :
// ===============================================================================
// Copyright ©yjq 2016 . All rights reserved.
// ===============================================================================
namespace LogMonitor.IDomianService
{
    public interface IBrowseLogRecordDomainService
    {
        #region 根据传输的日志内容获取浏览记录对象

        /// <summary>
        /// 根据传输的日志内容获取浏览记录对象
        /// </summary>
        /// <param name="logDeatis">传输的日志内容</param>
        /// <returns>浏览记录对象</returns>
        BrowseLogRecord CreateBrowseLogRecord(string logDeatis);

        #endregion 根据传输的日志内容获取浏览记录对象
    }
}