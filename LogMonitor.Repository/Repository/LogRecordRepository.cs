using LogMonitor.Domain.Model;
using LogMonitor.IRepository;
using LogMonitor.Repository.DbManage;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 13:53:10
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.Repository
{
    /// <summary>
    /// 日志数据访问
    /// </summary>
    public sealed class LogRecordRepository : BaseRepository<LogRecord, long>, ILogRecordRepository
    {
        public LogRecordRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}