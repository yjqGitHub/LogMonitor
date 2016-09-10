using LogMonitor.Domain.Model;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/10 10:19:10
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.IRepository
{
    public interface IProjectRepository : IBaseRepository<Project, int>
    {
        #region 根据项目代码获取项目信息

        /// <summary>
        /// 根据项目代码获取项目信息
        /// </summary>
        /// <param name="projectCode">项目代码</param>
        /// <returns>项目信息</returns>
        Project GetProjectInfo(string projectCode);

        #endregion 根据项目代码获取项目信息
    }
}