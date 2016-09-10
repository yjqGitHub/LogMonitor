/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/9 19:32:42
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.DomainEvent
{
    public sealed class SendEmailEvent : IEvent
    {
        /// <summary>
        /// 接收人列表
        /// </summary>
        public string[] ReceiveList { get; set; }

        /// <summary>
        /// 邮件主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Content { get; set; }
    }
}