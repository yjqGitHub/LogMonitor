/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/10 13:35:21
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.ValueObject
{
    public sealed class MemberInfo 
    {
        /// <summary>
        /// 成员Id
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// 成员名字
        /// </summary>
        public string MemberName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string MemberEmail { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string MemberMobile { get; set; }

        /// <summary>
        /// 是否为负责人
        /// </summary>
        public bool IsManager { get; set; }
    }
}