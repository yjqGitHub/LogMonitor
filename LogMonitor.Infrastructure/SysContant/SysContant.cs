/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 10:04:40
* Class Version       :    v1.0.0.0
* Class Description   :    常量
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public partial class SysContant
    {
        /// <summary>
        /// 监控管理后台日志记录器名称
        /// </summary>
        public const string LogerName_WebManage = "LogMonitorWebManage";

        /// <summary>
        /// 监控管理后接收服务志记录器名称
        /// </summary>
        public const string LogerName_ReceiveService = "LogMonitorReceiveService";

        /// <summary>
        /// App配置文件的路径
        /// </summary>
        public const string Path_AppConfig = "/App_Data/config/App.config";

        /// <summary>
        /// log4net的配置文件路径
        /// </summary>
        public const string Path_Log4NetConfig = "/App_Data/config/Log4Net.config";

        /// <summary>
        /// 解析ip地址的配置文件路径
        /// </summary>
        public const string Path_IpDataConfig = "/App_Data/config/ipdata.config";

        /// <summary>
        /// 日志监控接收模块
        /// </summary>
        public const string Module_ReceiveService = "LogMonitorReceiveService";
    }
}