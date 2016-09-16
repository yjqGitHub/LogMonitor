using LogMonitor.Infrastructure;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 11:55:33
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.DbManage
{
    public sealed class DbFactory : SelfDisposable, IDbFactory
    {
        private LogMonitorContext _logMonitorContext;

        public LogMonitorContext GetLogMonitorContext()
        {
            return _logMonitorContext ?? (_logMonitorContext = new LogMonitorContext());
        }

        protected override void DisposeCode()
        {
            _logMonitorContext?.Dispose();
        }
    }
}