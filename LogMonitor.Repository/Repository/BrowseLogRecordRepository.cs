using LogMonitor.Domain.Model;
using LogMonitor.IRepository;
using LogMonitor.Repository.DbManage;

// ===============================================================================
// Author              :    yjq
// Email               :    425527169@qq.com
// Create Time         :    2016/9/11 10:31:55
// ===============================================================================
// Class Version       :    v1.0.0.0
// Class Description   :
// ===============================================================================
// Copyright ©yjq 2016 . All rights reserved.
// ===============================================================================
namespace LogMonitor.Repository.Repository
{
    public sealed class BrowseLogRecordRepository : BaseRepository<BrowseLogRecord, long>, IBrowseLogRecordRepository
    {
        public BrowseLogRecordRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}