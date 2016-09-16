using LogMonitor.Domain.Model;
using LogMonitor.IRepository;
using LogMonitor.Repository.DbManage;
using System;
using System.Collections.Generic;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/10 17:09:51
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.Repository
{
    public sealed class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        #region 获取管理员列表

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <returns>管理员列表</returns>
        public IEnumerable<User> GetAdminList()
        {
            return this.LoadEntities(m => m.FIsDeleted == false && m.FIsAdmin == true);
        }

        #endregion 获取管理员列表
    }
}