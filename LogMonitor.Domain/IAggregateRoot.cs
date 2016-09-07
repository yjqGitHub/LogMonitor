/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 15:34:20
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain
{
    /// <summary>
    /// 聚合根
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IAggregateRoot<TKey> : IEntity<TKey>
    {
    }
}