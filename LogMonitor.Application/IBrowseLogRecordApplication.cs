﻿using System.Runtime.CompilerServices;
using System.Threading.Tasks;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/11 17:09:25
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Application
{
    public interface IBrowseLogRecordApplication
    {
        #region 添加一条浏览记录

        /// <summary>
        /// 添加一条浏览记录
        /// </summary>
        /// <param name="logDetail">日志内容</param>
        /// <param name="memberName">调用的方法名字</param>
        /// <param name="defaultLoggerName">默认日志记录器</param>
        /// <returns>true标识添加成功</returns>
        bool AddBrowseLog(string logDetail, [CallerMemberName] string memberName = null, string defaultLoggerName = null);

        #endregion 添加一条浏览记录

        #region 异步添加一条浏览记录

        /// <summary>
        /// 异步添加一条浏览记录
        /// </summary>
        /// <param name="logDetail">日志内容</param>
        /// <param name="memberName">调用的方法名字</param>
        /// <param name="defaultLoggerName">默认日志记录器</param>
        /// <returns>true标识添加成功</returns>
        Task<bool> AddBrowseLogAsync(string logDetail, [CallerMemberName] string memberName = null, string defaultLoggerName = null);

        #endregion 异步添加一条浏览记录
    }
}