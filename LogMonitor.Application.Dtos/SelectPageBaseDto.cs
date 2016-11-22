/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/26 14:55:57
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Application.Dtos
{
    /// <summary>
    /// 分页搜索基础数据
    /// </summary>
    public class SelectPageBaseDto
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页长
        /// </summary>
        public int PageSize { get; set; }
    }
}