using LogMonitor.Domain.ValueObject;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 15:56:34
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.Model
{
    /// <summary>
    /// 浏览记录
    /// </summary>
    public sealed class BrowseLogRecord : IAggregateRoot<long>
    {
        /// <summary>
        /// 主键、自增
        /// </summary>
        public long FId { get; set; }

        /// <summary>
        /// 日志详情
        /// </summary>
        public LogInfo LogInfo { get; set; }
    }
}