using LogMonitor.Domain.Model;

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
    }
}