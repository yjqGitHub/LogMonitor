using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/19 17:29:37
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    /// <summary>
    /// 自定义错误类型
    /// </summary>
    public sealed class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}