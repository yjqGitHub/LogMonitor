/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 10:10:47
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public partial class SysContant
    {
        /// <summary>
        /// 服务器邮箱地址的Key
        /// </summary>
        public const string Key_ServiceMailAddress = "ServiceMailAddress";

        /// <summary>
        /// 服务器邮箱密码的Key
        /// </summary>
        public const string Key_ServiceMailPwd = "ServiceMailPwd";

        public static object statiscLock = new object();
    }
}