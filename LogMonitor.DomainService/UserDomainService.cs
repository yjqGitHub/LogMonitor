using LogMonitor.Application.Dtos;
using LogMonitor.Domain.Model;
using LogMonitor.IDomianService;
using LogMonitor.Infrastructure;
using LogMonitor.Infrastructure.Extension;
using System;
using System.Linq.Expressions;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/19 17:20:26
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.DomainService
{
    public sealed class UserDomainService : IUserDomainService
    {
        public UserDomainService()
        {
        }

        #region 校验密码

        /// <summary>
        /// 校验密码
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <param name="pwd">密码</param>
        public void CheckPwd(User user, string pwd)
        {
            if (user == null) throw new ValidationException("用户不存在");
            if (string.IsNullOrWhiteSpace(pwd)) throw new ValidationException("密码不能为空");
            if (!string.Equals(user.FPwd, $"{pwd}{user.FSalt}".ToMd5(), StringComparison.OrdinalIgnoreCase))
            {
                throw new ValidationException("账号或密码错误");
            }
        }

        #endregion 校验密码

        #region 获取查询的条件lamda语句

        /// <summary>
        /// 获取查询的条件lamda语句
        /// </summary>
        /// <param name="selectDto">查询传输对象</param>
        /// <returns>查询的条件lamda语句</returns>
        public Expression<Func<User, bool>> GetSelectWhereLamda(UserSelectDto selectDto)
        {
            Expression<Func<User, bool>> whereLamda = ExpressionUtility.True<User>();
            if (!string.IsNullOrWhiteSpace(selectDto.FUserName))
            {
                whereLamda = whereLamda.And(m => m.FUserName.Contains(selectDto.FUserName));
            }
            if (!string.IsNullOrWhiteSpace(selectDto.FEmail))
            {
                whereLamda = whereLamda.And(m => m.FEmail.Contains(selectDto.FEmail));
            }
            if (!string.IsNullOrWhiteSpace(selectDto.FMobile))
            {
                whereLamda = whereLamda.And(m => m.FMobile.Contains(selectDto.FMobile));
            }
            if (!string.IsNullOrWhiteSpace(selectDto.FName))
            {
                whereLamda = whereLamda.And(m => m.FName.Contains(selectDto.FName));
            }
            if (selectDto.FIsAdmin != null)
            {
                whereLamda = whereLamda.And(m => m.FIsAdmin == selectDto.FIsAdmin);
            }
            return whereLamda;
        }

        #endregion 获取查询的条件lamda语句
    }
}