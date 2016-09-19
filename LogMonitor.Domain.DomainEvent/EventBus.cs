using LogMonitor.Infrastructure;
using LogMonitor.Infrastructure.Extension;
using System.Collections.Generic;
using System.Threading.Tasks;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/9 18:30:19
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.DomainEvent
{
    public sealed class EventBus : IEventBus
    {
        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventHandlers = ObjectContainer.Current.Resolve<IEnumerable<IEventHandler<TEvent>>>();
            eventHandlers.ForEach(eventHandle =>
            {
                eventHandle.Handle(@event);
            });
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventHandlers = ObjectContainer.Current.Resolve<IEnumerable<IEventHandler<TEvent>>>();
            foreach (var eventHandle in eventHandlers)
            {
                await eventHandle.HandleAsync(@event);
            }
        }
    }
}