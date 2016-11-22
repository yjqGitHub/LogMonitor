using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 10:25:02
* Class Version       :    v1.0.0.0
* Class Description   :    json解析帮助类
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public class NewtonsoftJsonSerializer : IJsonSerializer
    {
        public JsonSerializerSettings Settings { get; private set; }

        public NewtonsoftJsonSerializer()
        {
            Settings = new JsonSerializerSettings
            {
                //Converters = new List<JsonConverter> { new IsoDateTimeConverter() { DateTimeFormat = "yyyyMMdd HH:mm:ss ff" } },
                ContractResolver = new CustomContractResolver(),
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };
        }

        /// <summary>Serialize an object to json string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize(object obj)
        {
            return obj == null ? null : JsonConvert.SerializeObject(obj, Settings);
        }

        /// <summary>Deserialize a json string to an object.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Deserialize(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type, Settings);
        }

        /// <summary>Deserialize a json string to a strong type object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Deserialize<T>(string value) where T : class
        {
            return JsonConvert.DeserializeObject<T>(value, Settings);
        }

        private class CustomContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var jsonProperty = base.CreateProperty(member, memberSerialization);
                if (jsonProperty.Writable) return jsonProperty;
                var property = member as PropertyInfo;
                if (property == null) return jsonProperty;
                var hasPrivateSetter = property.GetSetMethod(true) != null;
                jsonProperty.Writable = hasPrivateSetter;

                return jsonProperty;
            }
        }
    }
}