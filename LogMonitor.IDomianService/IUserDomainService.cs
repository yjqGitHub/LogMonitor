using LogMonitor.Application.Dtos;
using LogMonitor.Domain.Model;
using System;
using System.Linq.Expressions;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/19 17:18:34
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.IDomianService
{
    public interface IUserDomainService
    {
        #region 校验用户的密码

        /// <summary>
        /// 校验用户的密码
        /// </summary>
        /// <param name="user">需要校验的用户信息</param>
        /// <param name="pwd">密码</param>
        void CheckPwd(User user, string pwd);

        #endregion 校验用户的密码

        #region 获取查询的条件lamda语句

        /// <summary>
        /// 获取查询的条件lamda语句
        /// </summary>
        /// <param name="selectDto">查询传输对象</param>
        /// <returns>查询的条件lamda语句</returns>
        Expression<Func<User, bool>> GetSelectWhereLamda(UserSelectDto selectDto);

        #endregion 获取查询的条件lamda语句
    }
}