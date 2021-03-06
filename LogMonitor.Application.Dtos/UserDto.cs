﻿using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/26 11:57:03
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Application.Dtos
{
    public sealed class UserDto
    {
        /// <summary>
        /// 主键、自增(用户Id)
        /// </summary>
        public int FId { get; set; }

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
        public bool FIsAdmin { get; set; }

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