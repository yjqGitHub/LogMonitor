using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 15:44:19
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.Model
{
    /// <summary>
    /// 项目人员关系
    /// </summary>
    public sealed class ProjectPerson : IAggregateRoot<int>
    {
        /// <summary>
        /// 主Id，自增
        /// </summary>
        public int FId { get; set; }

        /// <summary>
        /// 项目Id
        /// </summary>
        public int FProjectId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int FUserId { get; set; }

        /// <summary>
        /// 是否为管理人员
        /// </summary>
        public bool FIsManager { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool FIsDeleted { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime FAddTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? FModifyTime { get; set; }
    }
}