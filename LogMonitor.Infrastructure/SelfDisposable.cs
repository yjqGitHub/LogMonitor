using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 10:40:10
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public class SelfDisposable : IDisposable
    {
        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool isDisposing)
        {
            if (!_isDisposed && isDisposing)
            {
                DisposeCode();
            }
            _isDisposed = true;
        }

        protected virtual void DisposeCode()
        {
        }

        ~SelfDisposable()
        {
            Dispose(false);
        }
    }
}