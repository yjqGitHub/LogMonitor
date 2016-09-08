using LogMonitor.IUnitOfWork;
using LogMonitor.Repository.DbManage;
using System.Threading.Tasks;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 12:04:28
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.UnitOfWork
{
    public sealed class LogMonitorUnitOfWork : ILogMonitorUnitOfWork
    {
        private readonly IDbFactory _dbFactory;

        public LogMonitorUnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public bool Commit()
        {
            return _dbFactory.GetLogMonitorContext().SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return await _dbFactory.GetLogMonitorContext().SaveChangesAsync() > 0;
        }
    }
}