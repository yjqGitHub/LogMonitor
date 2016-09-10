using LogMonitor.Infrastructure;
using System.Threading.Tasks;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/9 19:35:39
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.DomainEvent
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    public sealed class SendEmailEventHandler : IEventHandler<SendEmailEvent>, IEventHandler<DangerLogHappendEvent>
    {
        #region DangerLogHappendEvent

        public void Handle(DangerLogHappendEvent @event)
        {
            EmailHelper.SendEmail(@event.ReceiverEmailList, @event.Title, @event.Message);
        }

        public async Task HandleAsync(DangerLogHappendEvent @event)
        {
            await EmailHelper.SendEmailAsync(@event.ReceiverEmailList, @event.Title, @event.Message);
        }

        #endregion DangerLogHappendEvent

        #region SendEmailEvent

        public void Handle(SendEmailEvent @event)
        {
            EmailHelper.SendEmail(@event.ReceiveList, @event.Subject, @event.Content);
        }

        public async Task HandleAsync(SendEmailEvent @event)
        {
            await EmailHelper.SendEmailAsync(@event.ReceiveList, @event.Subject, @event.Content);
        }

        #endregion SendEmailEvent
    }
}