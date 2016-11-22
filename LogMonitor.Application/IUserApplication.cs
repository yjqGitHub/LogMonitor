using LogMonitor.Application.Dtos;
using LogMonitor.Infrastructure;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/19 16:49:45
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Application
{
    public interface IUserApplication
    {
        #region 登录

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        ValidationModel Login(string userName, string pwd);

        #endregion 登录

        #region 获取用户列表

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="selectDto">用户查询条件传输对象</param>
        /// <returns>用户列表</returns>
        PageResult<UserDto> GetUserList(UserSelectDto selectDto);

        #endregion 获取用户列表
    }
}