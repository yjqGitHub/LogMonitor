using System.Text;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 14:47:07
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure.Extension
{
    public static partial class Extension
    {
        #region 将字节数组转为默认编码字符

        /// <summary>
        /// 将字节数组转为默认编码字符
        /// </summary>
        /// <param name="buffer">要转换的字节数组</param>
        /// <returns>默认编码字符</returns>
        public static string GetString(this byte[] buffer)
        {
            return Encoding.Default.GetString(buffer);
        }

        #endregion 将字节数组转为默认编码字符
    }
}