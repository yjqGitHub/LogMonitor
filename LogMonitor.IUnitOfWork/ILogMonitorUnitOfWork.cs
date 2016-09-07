using System.Threading.Tasks;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 16:05:05
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.IUnitOfWork
{
    public interface ILogMonitorUnitOfWork
    {
        #region 提交保存

        /// <summary>
        /// 提交保存
        /// </summary>
        /// <returns>bool</returns>
        bool Commit();

        #endregion 提交保存

        #region 异步提交保存

        /// <summary>
        /// 异步提交保存
        /// </summary>
        /// <returns>bool</returns>
        Task<bool> CommitAsync();

        #endregion 异步提交保存
    }
}