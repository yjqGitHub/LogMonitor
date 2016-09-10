using System.Runtime.CompilerServices;
using System.Xml;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 10:14:58
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    public sealed class ConfigHelper
    {
        #region 根据Key获取app配置文件的设置的值

        /// <summary>
        /// 根据Key获取app配置文件的设置的值
        /// </summary>
        /// <param name="key">获取的Key</param>
        /// <param name="memberName">调用成员</param>
        /// <param name="defaultLoggerName">默认日志记录名</param>
        /// <returns>app配置文件的设置的值</returns>
        public static string GetValue(string key, [CallerMemberName] string memberName = null, string defaultLoggerName = SysContant.LoggerName_Default)
        {
            return ExceptionHelper.IgnoreButLogException(() =>
            {
                XmlDocument xmlDoc = LoadAppXml();
                var xmlNode = xmlDoc.SelectSingleNode("//appSettings");
                if (xmlNode != null)
                {
                    XmlElement xmlElement = xmlNode.SelectSingleNode("//add[@key='" + key + "']") as XmlElement;
                    if (xmlElement != null)
                    {
                        return xmlElement.GetAttribute("value");
                    }
                }
                return null;
            }, memberName: memberName, defaultLoggerName: defaultLoggerName);
        }

        #endregion 根据Key获取app配置文件的设置的值

        #region 根据Key设置app配置文件的值，没有则添加

        /// <summary>
        /// 根据Key设置app配置文件的值，没有则添加
        /// </summary>
        /// <param name="key">要设置的Key</param>
        /// <param name="value">设置的值</param>
        /// <param name="memberName">调用成员</param>
        /// <param name="defaultLoggerName">默认日志记录名</param>
        public static void SetValue(string key, string value, [CallerMemberName] string memberName = null, string defaultLoggerName = SysContant.LoggerName_Default)
        {
            ExceptionHelper.IgnoreButLogException(() =>
            {
                XmlDocument xDoc = LoadAppXml();
                XmlNode xNode;
                XmlElement xElem1;
                XmlElement xElem2;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem1 = xNode.SelectSingleNode("//add[@key='" + key + "']") as XmlElement;
                if (xElem1 != null)
                {
                    xElem1.SetAttribute("value", value);
                }
                else
                {
                    xElem2 = xDoc.CreateElement("add");
                    xElem2.SetAttribute("key", key);
                    xElem2.SetAttribute("value", value);
                    xNode.AppendChild(xElem2);
                }
                xDoc.Save(PathHelper.GetAppConfigPath());
            }, memberName: memberName, defaultLoggerName: defaultLoggerName);
        }

        #endregion 根据Key设置app配置文件的值，没有则添加

        #region 加载App配置文件

        /// <summary>
        /// 加载App配置文件
        /// </summary>
        /// <returns>App配置文件</returns>
        private static XmlDocument LoadAppXml()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(PathHelper.GetAppConfigPath());
            return xmlDoc;
        }

        #endregion 加载App配置文件
    }
}