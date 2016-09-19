using LogMonitor.Infrastructure;
using System.Threading.Tasks;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/19 18:48:08
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.DomainEvent
{
    public sealed class UserLoginEventHandler : IEventHandler<UserLoginEvent>
    {
        private readonly ILogger _logger;

        public UserLoginEventHandler()
        {
            _logger = ObjectContainer.Current.Resolve<ILoggerFactory>().Create(SysContant.LoggerName_Default);
        }

        public void Handle(UserLoginEvent @event)
        {
            _logger.Info(string.Format("用户ID：{0}，登录成功", @event.UserId.ToString()));
        }

        public async Task HandleAsync(UserLoginEvent @event)
        {
            await Task.Delay(1);
            _logger.Info(string.Format("用户ID：{0}，登录成功", @event.UserId.ToString()));
        }
    }
}