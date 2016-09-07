using System;
using System.IO;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 10:06:24
* Class Version       :    v1.0.0.0
* Class Description   :    路径帮助
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public sealed class PathHelper
    {
        #region 获取当前项目的路径

        /// <summary>
        /// 获取当前项目的路径
        /// </summary>
        /// <returns>当前项目的路径</returns>
        public static string GetMapPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        #endregion 获取当前项目的路径

        #region 获取配置文件的路径

        /// <summary>
        /// 获取配置文件的路径
        /// </summary>
        /// <returns>配置文件的路径</returns>
        public static string GetAppConfigPath()
        {
            return Path.Combine(GetMapPath(), SysContant.Path_AppConfig);
        }

        #endregion 获取配置文件的路径
    }
}