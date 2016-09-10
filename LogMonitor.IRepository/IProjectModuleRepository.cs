using LogMonitor.Domain.Model;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/10 13:59:49
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.IRepository
{
    public interface IProjectModuleRepository : IBaseRepository<ProjectModule, int>
    {
        #region 根据模块代码查询模块信息(负责人信息)

        /// <summary>
        /// 根据模块代码查询模块信息(负责人信息)
        /// </summary>
        /// <param name="moduleCode">模块代码</param>
        /// <param name="projectCode">项目代码</param>
        /// <returns>模块信息(负责人信息)</returns>
        ProjectModule GetProjectModule(string moduleCode, string projectCode);

        #endregion 根据模块代码查询模块信息(负责人信息)
    }
}