using LogMonitor.Infrastructure;
using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/19 17:44:22
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.DomainEvent
{
    public sealed class UserLoginEvent : IEvent
    {
        private int _userId;
        private DateTime _loginTime;

        public UserLoginEvent(int userId)
        {
            _userId = userId;
            _loginTime = DateTime.Now;
            UserAgent = WebHelper.GetUserAgent();
            LoginIp = WebHelper.GetRealIP();
        }

        /// <summary>
        /// 登录用户Id
        /// </summary>
        public int UserId { get { return _userId; } }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get { return _loginTime; } }

        /// <summary>
        /// 客户端信息
        /// </summary>
        public string UserAgent { get; private set; }

        /// <summary>
        /// 登录Ip
        /// </summary>
        public string LoginIp { get; private set; }
    }
}