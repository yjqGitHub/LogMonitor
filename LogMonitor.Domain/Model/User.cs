using LogMonitor.Domain.DomainEvent;
using LogMonitor.Infrastructure;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 15:11:02
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    public sealed class User : IAggregateRoot<int>
    {
        /// <summary>
        /// 主键、自增(用户Id)
        /// </summary>
        public int FId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string FUserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string FPwd { get; set; }

        /// <summary>
        /// 盐值
        /// </summary>
        public string FSalt { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string FEmail { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string FMobile { get; set; }

        /// <summary>
        /// 是否为管理员
        /// </summary>
        public bool FIsAdmin { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool FIsDeleted { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime FAddTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? FModifyTime { get; set; }

        #region 登录

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="memberName">调用的方法</param>
        /// <param name="defaultLoggerName">默认记录器名字</param>
        /// <returns></returns>
        public async Task LoginAsync([CallerMemberName] string memberName = null, string defaultLoggerName = null)
        {
            await ExceptionHelper.IgnoreButLogExceptionAsync(async () =>
            {
                IEventBus eventBus = ObjectContainer.Current.Resolve<IEventBus>();
                UserLoginEvent loginEvent = new UserLoginEvent(this.FId);
                await eventBus.PublishAsync(loginEvent);
            }, memberName: memberName, defaultLoggerName: defaultLoggerName);
        }

        #endregion 登录
    }
}