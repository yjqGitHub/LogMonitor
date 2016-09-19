/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 13:20:18
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public enum LifeStyle
    {
        /// <summary>
        /// 默认
        /// </summary>
        Transient = 1,

        /// <summary>
        /// 单例
        /// </summary>
        Singleton = 2,

        /// <summary>
        /// 在一个生命周期域中，每一个依赖或调用创建一个单一的共享的实例，且每一个不同的生命周期域，实例是唯一的，不共享的。
        /// </summary>
        PerLifetimeScope = 3,

        /// <summary>
        /// 在一个http请求生命周期域中，每一个依赖或调用创建一个单一的共享的实例，且每一个不同的生命周期域，实例是唯一的，不共享的。
        /// </summary>
        RequestLifetimeScope = 4
    }
}