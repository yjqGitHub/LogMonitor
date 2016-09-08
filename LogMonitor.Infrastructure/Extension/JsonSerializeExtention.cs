/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 16:06:34
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure.Extension
{
    public static partial class Extension
    {
        /// <summary>
        /// 将对象转换为json格式的字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj"></param>
        /// <returns>json格式的字符串</returns>
        public static string ToJson<T>(this T obj) where T : class, new()
        {
            IJsonSerializer jsonSerialize = ObjectContainer.Current.Resolve<IJsonSerializer>();
            return jsonSerialize.Serialize(obj);
        }
    }
}