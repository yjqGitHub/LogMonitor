using LogMonitor.Domain.ValueObject;
using System;
using System.Collections.Generic;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 15:42:39
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.Model
{
    /// <summary>
    /// 项目
    /// </summary>
    public sealed class Project : IAggregateRoot<int>
    {
        /// <summary>
        /// 主Id，自增
        /// </summary>
        public int FId { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string FProjectName { get; set; }

        /// <summary>
        /// 项目代码(唯一不能重复)
        /// </summary>
        public string FProjectCode { get; set; }

        /// <summary>
        /// 项目描述
        /// </summary>
        public string FDescription { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool FIsDeleted { get; set; }

        /// <summary>
        /// 创建人(0系统)
        /// </summary>
        public int FCreater { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime FAddTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? FModifyTime { get; set; }

        /// <summary>
        /// 项目成员
        /// </summary>
        public IEnumerable<MemberInfo> Members { get; set; }
    }
}