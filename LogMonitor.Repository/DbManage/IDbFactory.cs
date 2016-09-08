using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 11:54:41
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.DbManage
{
    public interface IDbFactory : IDisposable
    {
        LogMonitorContext GetLogMonitorContext();
    }
}