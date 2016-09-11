// ===============================================================================
// Author              :    yjq
// Email               :    425527169@qq.com
// Create Time         :    2016/9/11 16:01:43
// ===============================================================================
// Class Version       :    v1.0.0.0
// Class Description   :
// ===============================================================================
// Copyright ©yjq 2016 . All rights reserved.
// ===============================================================================
namespace LogMonitor.Infrastructure.Extension
{
    public static partial class Extension
    {
        #region 根据Ip获取Ip所在的城市信息

        /// <summary>
        /// 根据Ip获取Ip所在的城市信息
        /// </summary>
        /// <param name="ip">要获取的Ip</param>
        /// <returns>Ip所在的城市信息</returns>
        public static string SearchLocation(this string ip)
        {
            if (!string.IsNullOrWhiteSpace(ip))
            {
                IPLocation location = IpDataHelper.SearchLocation(ip);
                if (location != null)
                {
                    return $"{location.Country}{location.Area}";
                }
            }
            return string.Empty;
        }

        #endregion 根据Ip获取Ip所在的城市信息
    }
}