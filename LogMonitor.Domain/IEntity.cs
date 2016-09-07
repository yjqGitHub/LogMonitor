/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 15:31:07
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain
{
    /// <summary>
    /// 实体类型
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        TKey FId { get; set; }
    }
}