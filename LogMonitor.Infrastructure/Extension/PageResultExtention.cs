using System.Collections.Generic;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/26 14:51:10
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure.Extension
{
    public static partial class Extension
    {
        #region 将数据进行分页处理

        /// <summary>
        /// 将数据进行分页处理
        /// </summary>
        /// <typeparam name="T">数据对象类型</typeparam>
        /// <param name="data">数据内容</param>
        /// <param name="index">当前页码</param>
        /// <param name="size">页长</param>
        /// <returns>分页结果</returns>
        public static PageResult<T> ToPageList<T>(this IEnumerable<T> data, int index, int size) where T : class, new()
        {
            return new PageResult<T>(data, index, size);
        }

        #endregion 将数据进行分页处理
    }
}