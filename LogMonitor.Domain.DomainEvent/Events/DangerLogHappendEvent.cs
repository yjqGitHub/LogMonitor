/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/9 19:53:34
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.DomainEvent
{
    /// <summary>
    /// 危险记录发生事件
    /// </summary>
    public sealed class DangerLogHappendEvent : IEvent
    {
        /// <summary>
        /// 接收人邮箱列表
        /// </summary>
        public string[] ReceiverEmailList { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 错误信息描述内容
        /// </summary>
        public string Message { get; set; }
    }
}