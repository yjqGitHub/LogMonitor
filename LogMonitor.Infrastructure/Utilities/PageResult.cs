using System.Collections.Generic;
using System.Linq;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/26 14:24:31
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public sealed class PageResult<T> where T : class, new()
    {
        #region private field

        private int _index;
        private int _pageSize;
        private int _totalCount;
        private int _totalPage;
        private IEnumerable<T> _pageData;

        #endregion private field

        public PageResult(IEnumerable<T> data, int index, int size)
        {
            if (data != null)
            {
                _totalCount = data.Count();
            }
            else
            {
                _totalCount = 0;
            }
            _index = ToolUtility.MaxValue(index, 1);
            _pageSize = ToolUtility.MaxValue(1, size);
            _totalPage = (_totalCount + _pageSize - 1) / (_pageSize);
            _pageData = data?.Skip(ToolUtility.MaxValue(_index - 1, 0) * _pageSize).Take(_pageSize);
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex
        {
            get
            {
                return ToolUtility.MaxValue(_index, 1);
            }
        }

        /// <summary>
        /// 页长
        /// </summary>
        public int PageSize
        {
            get
            {
                return ToolUtility.MaxValue(1, _pageSize);
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get { return _totalCount; } }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage
        {
            get
            {
                return _totalPage;
            }
        }

        /// <summary>
        /// 当前页面内容
        /// </summary>
        public IEnumerable<T> PageData { get { return _pageData; } }
    }
}