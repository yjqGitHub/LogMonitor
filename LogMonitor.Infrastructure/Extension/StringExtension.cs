using System.Security.Cryptography;
using System.Text;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/19 15:55:09
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure.Extension
{
    public static partial class Extension
    {
        /// <summary>
        /// 将字符转为默认字节数组
        /// </summary>
        /// <param name="str">要转换的字符</param>
        /// <returns>字节数组</returns>
        public static byte[] ToBytes(this string str)
        {
            return Encoding.Default.GetBytes(str);
        }

        /// <summary>
        /// 将字符转为utf8字节数组
        /// </summary>
        /// <param name="str">要转换的字符</param>
        /// <returns>字节数组</returns>
        public static byte[] ToUtf8Bytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// 将字符转换为md5密文
        /// </summary>
        /// <param name="clearText">要转换的明文</param>
        /// <param name="defaultProvider">默认转换格式</param>
        /// <returns>md5密文</returns>
        public static string ToMd5(this string clearText, string defaultProvider = null)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(clearText.ToUtf8Bytes());
            StringBuilder cipherBuilder = new StringBuilder();
            hashBytes.ForEach(hashbyte =>
            {
                cipherBuilder.Append(hashbyte.ToString(defaultProvider ?? "X2"));
            });
            return cipherBuilder.ToString();
        }

        #region 判断字符不能空

        /// <summary>
        /// 判断字符不能空
        /// </summary>
        /// <param name="str">要判断的字符</param>
        /// <returns>不为空 则为true 空则为false</returns>
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        #endregion 判断字符不能空
    }
}