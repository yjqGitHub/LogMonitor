using System;
using System.Text;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/17 14:46:16
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure.Extension
{
    public static partial class Extension
    {
        /// <summary>
        /// 获取错误异常信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns>错误异常信息</returns>
        public static string ToErrorMsg(this Exception ex, string memberName = null)
        {
            StringBuilder errorBuilder = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(memberName))
            {
                errorBuilder.AppendFormat("CallerMemberName：{0}", memberName).AppendLine();
            }
            errorBuilder.AppendFormat("Message：{0}", ex.Message).AppendLine();
            if (ex.InnerException != null)
            {
                if (!string.Equals(ex.Message, ex.InnerException.Message, StringComparison.OrdinalIgnoreCase))
                {
                    errorBuilder.AppendFormat("InnerException：{0}", ex.InnerException.Message).AppendLine();
                }
            }
            errorBuilder.AppendFormat("Source：{0}", ex.Source).AppendLine();
            errorBuilder.AppendFormat("StackTrace：{0}", ex.StackTrace).AppendLine();
            if (WebHelper.IsHaveHttpContext())
            {
                errorBuilder.AppendFormat("RealIP：{0}", WebHelper.GetRealIP()).AppendLine();
                errorBuilder.AppendFormat("HttpRequestUrl：{0}", WebHelper.GetHttpRequestUrl()).AppendLine();
                errorBuilder.AppendFormat("UserAgent：{0}", WebHelper.GetUserAgent()).AppendLine();
            }
            return errorBuilder.ToString();
        }
    }
}