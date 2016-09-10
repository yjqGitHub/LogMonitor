using LogMonitor.Domain.Model;
using System.Collections.Generic;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/10 17:08:08
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.IRepository
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
        #region 获取管理员列表

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <returns>管理员列表</returns>
        IEnumerable<User> GetAdminList();

        #endregion 获取管理员列表
    }
}