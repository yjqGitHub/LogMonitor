using System.Threading.Tasks;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/9 18:24:57
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.DomainEvent
{
    public interface IEventHandler<TEvent> where TEvent : IEvent
    {
        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="event">事件</param>
        /// <returns></returns>
        Task HandleAsync(TEvent @event);

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="event">事件</param>
        void Handle(TEvent @event);
    }
}