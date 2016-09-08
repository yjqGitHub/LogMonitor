using LogMonitor.Domain.Model;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 13:50:07
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.IRepository
{
    /// <summary>
    /// 日志数据交互接口
    /// </summary>
    public interface ILogRecordRepository : IBaseRepository<LogRecord, long>
    {
    }
}