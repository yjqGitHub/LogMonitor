/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/19 17:10:11
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public sealed class ValidationModel
    {
        private OperateResultTypeEnum _state;
        private object _content;

        public ValidationModel(OperateResultTypeEnum state)
        {
            _state = state;
        }

        public ValidationModel(OperateResultTypeEnum state, object content) : this(state)
        {
            _content = content;
        }

        /// <summary>
        /// 操作结果类型
        /// </summary>
        public OperateResultTypeEnum State { get { return _state; } }

        /// <summary>
        /// 结果内容
        /// </summary>
        public object Content { get; set; }
    }
}