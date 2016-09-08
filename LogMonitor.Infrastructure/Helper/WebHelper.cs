using System;
using System.Linq;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 13:15:24
* Class Version       :    v1.0.0.0
* Class Description   :    网络请求帮助
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public sealed class WebHelper
    {
        #region 获取当前网络IP

        /// <summary>
        /// 获取当前网络IP
        /// </summary>
        /// <returns>当前网络IP</returns>
        public static string GetRealIP()
        {
            if (IsHaveHttpContext()) return string.Empty;
            string result = string.Empty;
            if (System.Web.HttpContext.Current.Request.Headers != null)
            {
                var forwardedHttpHeader = "X-FORWARDED-FOR";
                string xff = System.Web.HttpContext.Current.Request.Headers.AllKeys
                    .Where(x => forwardedHttpHeader.Equals(x, StringComparison.InvariantCultureIgnoreCase))
                    .Select(k => System.Web.HttpContext.Current.Request.Headers[k])
                    .FirstOrDefault();
                if (!String.IsNullOrEmpty(xff))
                {
                    string lastIp = xff.Split(new char[] { ',' }).FirstOrDefault();
                    result = lastIp;
                }
            }
            if (String.IsNullOrEmpty(result) && System.Web.HttpContext.Current.Request.UserHostAddress != null)
            {
                result = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            if (result == "::1")
                result = "127.0.0.1";
            if (!String.IsNullOrEmpty(result))
            {
                int index = result.IndexOf(":", StringComparison.InvariantCultureIgnoreCase);
                if (index > 0)
                    result = result.Substring(0, index);
            }
            else result = "0.0.0.0";
            return result;
        }

        #endregion 获取当前网络IP

        #region 获取客户端浏览器的原始用户代理信息

        /// <summary>
        /// 获取客户端浏览器的原始用户代理信息
        /// </summary>
        /// <returns></returns>
        public static string GetUserAgent()
        {
            if (IsHaveHttpContext())
                return System.Web.HttpContext.Current.Request.UserAgent;
            return string.Empty;
        }

        #endregion 获取客户端浏览器的原始用户代理信息

        #region 获取请求类型

        /// <summary>
        /// 获取请求类型
        /// </summary>
        /// <returns>请求类型</returns>
        public static string GetHttpMethod()
        {
            if (IsHaveHttpContext())
                return System.Web.HttpContext.Current.Request.RequestType;
            return string.Empty;
        }

        #endregion 获取请求类型

        #region 获取请求地址

        /// <summary>
        /// 获取请求地址
        /// </summary>
        /// <returns>请求地址</returns>
        public static string GetHttpRequestUrl()
        {
            if (IsHaveHttpContext())
                return System.Web.HttpContext.Current.Request.Url.ToString();
            return string.Empty;
        }

        #endregion 获取请求地址

        #region 判断是否有网络请求上下文
        /// <summary>
        /// 判断是否有网络请求上下文
        /// </summary>
        /// <returns></returns>
        public static bool IsHaveHttpContext()
        {
            return (System.Web.HttpContext.Current != null);
        } 
        #endregion
    }
}