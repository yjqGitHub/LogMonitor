using LogMonitor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

        #region 加载用户列表，分页使用

        /// <summary>
        /// 加载用户列表，分页使用
        /// </summary>
        /// <param name="whereLamda">查询条件</param>
        /// <param name="orderLamda">排序字段</param>
        /// <param name="isDesc">是否倒叙排列</param>
        /// <returns>用户列表</returns>
        IEnumerable<User> GetUserList(Expression<Func<User, bool>> whereLamda, string orderColumn, bool isDesc);

        #endregion 加载用户列表，分页使用
    }
}