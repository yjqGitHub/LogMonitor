using System;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 14:53:10
* Class Version       :    v1.0.0.0
* Class Description   :    json序列化
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public interface IJsonSerializer
    {
        string Serialize(object obj);

        object Deserialize(string value, Type type);

        T Deserialize<T>(string value) where T : class;
    }
}