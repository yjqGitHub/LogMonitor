/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/17 14:21:20
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure.Extension
{
    public static partial class Extension
    {
        /// <summary>
        /// 将日志等级转为日志类型的枚举
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static LogTypeEnum ToLogType(this string str)
        {
            LogTypeEnum logType;
            switch (str.ToUpper())
            {
                case "DEBUG":
                    logType = LogTypeEnum.Debug;
                    break;

                case "INFO":
                    logType = LogTypeEnum.Info;
                    break;

                case "WARN":
                    logType = LogTypeEnum.Warning;
                    break;

                case "ERROR":
                    logType = LogTypeEnum.Error;
                    break;

                case "FATAL":
                    logType = LogTypeEnum.Fatal;
                    break;

                default:
                    logType = LogTypeEnum.Unfind;
                    break;
            }
            return logType;
        }
    }
}