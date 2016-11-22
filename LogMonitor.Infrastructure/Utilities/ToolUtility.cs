/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/26 11:47:25
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public sealed class ToolUtility
    {
        /// <summary>
        /// 获取两个值中的最大值
        /// </summary>
        /// <param name="num1">值1</param>
        /// <param name="num2">值2</param>
        /// <returns>两个值中的最大值</returns>
        public static int MaxValue(int num1, int num2)
        {
            return num1 > num2 ? num1 : num2;
        }
    }
}