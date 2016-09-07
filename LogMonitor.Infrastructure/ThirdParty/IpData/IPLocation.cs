/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 20:53:49
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public sealed class IPLocation
    {
        private string _country;//国家
        private string _area;//区域

        /// <summary>
        /// 国家
        /// </summary>
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// 区域
        /// </summary>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public override string ToString()
        {
            return string.Concat(Country, Area);
        }
    }
}