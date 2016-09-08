using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 9:13:02
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.Model
{
    /// <summary>
    /// 项目模块
    /// </summary>
    public sealed class ProjectModule : IAggregateRoot<int>
    {
        /// <summary>
        /// 主Id，自增
        /// </summary>
        public int FId { get; set; }

        /// <summary>
        /// 所属项目Id
        /// </summary>
        public int FProjectId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string FModuleName { get; set; }

        /// <summary>
        /// 模块代码(同一项目下唯一不能重复)
        /// </summary>
        public string FModuleCode { get; set; }

        /// <summary>
        /// 模块描述
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
    }
}