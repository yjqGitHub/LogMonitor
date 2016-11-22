/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/26 12:01:35
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Application.Dtos
{
    public sealed class UserSelectDto : SelectPageBaseDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string FUserName { get; set; }

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
        public bool? FIsAdmin { get; set; }

        /// <summary>
        /// 是否倒叙排列
        /// </summary>
        public bool IsDesc { get; set; } = true;

        /// <summary>
        /// 排序列名
        /// </summary>
        public string SortColumn { get; set; }
    }
}