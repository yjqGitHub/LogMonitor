/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 10:20:09
* Class Version       :    v1.0.0.0
* Class Description   :    日志类型
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public enum LogTypeEnum
    {
        /// <summary>
        /// 监控
        /// </summary>
        Monitor = 1,

        /// <summary>
        /// 错误
        /// </summary>
        Error = 2,

        /// <summary>
        /// 调试
        /// </summary>
        Debug = 3,

        /// <summary>
        /// 普通
        /// </summary>
        Info = 4,

        /// <summary>
        /// 警告
        /// </summary>
        Warning = 5
    }
}