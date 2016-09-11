using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static LogMonitor.Infrastructure.WebHelper;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/8/31 16:14:01
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    /// <summary>
    /// 异常帮助
    /// </summary>
    public sealed class ExceptionHelper
    {
        #region 忽略方法抛出的异常

        /// <summary>
        /// 忽略方法抛出的异常
        /// </summary>
        /// <param name="action">执行的方法</param>
        public static void IgnoreException(Action action)
        {
            try
            {
                action();
            }
            catch { }
        }

        /// <summary>
        /// 忽略方法抛出的异常
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="action">执行的方法</param>
        /// <param name="defaultValue">默认返回值</param>
        /// <returns>如果没异常，返回值就是正常返回值，假如出现了异常，返回值就是默认的值</returns>
        public static T IgnoreException<T>(Func<T> action, T defaultValue = default(T))
        {
            try
            {
                return action();
            }
            catch
            {
                return defaultValue;
            }
        }

        #endregion 忽略方法抛出的异常

        #region 忽略异常，但记录异常

        /// <summary>
        /// 忽略异常，但记录异常
        /// </summary>
        /// <param name="action">执行的方法</param>
        /// <param name="memberName">调用成员信息</param>
        /// <param name="defaultLoggerName">默认的日志文件名字</param>
        public static void IgnoreButLogException(Action action, [CallerMemberName] string memberName = null, string defaultLoggerName = null)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                ILogger logger = ObjectContainer.Current.Resolve<ILoggerFactory>().Create(defaultLoggerName ?? SysContant.LoggerName_Default);
                logger.Error(GetJsonErrorLog(ex, memberName: memberName));
            }
        }

        /// <summary>
        /// 忽略异常，但记录异常
        /// </summary>
        /// <param name="action">执行的方法</param>
        /// <param name="memberName">调用成员信息</param>
        /// <param name="defaultLoggerName">默认的日志文件名字</param>
        public static async Task IgnoreButLogExceptionAsync(Func<Task> action, [CallerMemberName] string memberName = null, string defaultLoggerName = null)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                ILogger logger = ObjectContainer.Current.Resolve<ILoggerFactory>().Create(defaultLoggerName ?? SysContant.LoggerName_Default);
                logger.Error(GetJsonErrorLog(ex, memberName: memberName));
            }
        }

        /// <summary>
        /// 忽略异常，但记录异常
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="action">执行的方法</param>
        /// <param name="defaultValue">默认返回值</param>
        /// <param name="memberName">调用成员信息</param>
        /// <param name="defaultLoggerName">默认的日志文件名字</param>
        /// <returns>如果没异常，返回值就是正常返回值，假如出现了异常，返回值就是默认的值</returns>
        public static T IgnoreButLogException<T>(Func<T> action, T defaultValue = default(T), [CallerMemberName] string memberName = null, string defaultLoggerName = null)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                ILogger logger = ObjectContainer.Current.Resolve<ILoggerFactory>().Create(defaultLoggerName ?? SysContant.LoggerName_Default);
                logger.Error(GetJsonErrorLog(ex, memberName: memberName));
                return defaultValue;
            }
        }

        /// <summary>
        /// 忽略异常，但记录异常
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="action">执行的方法</param>
        /// <param name="defaultValue">默认返回值</param>
        /// <param name="memberName">调用成员信息</param>
        /// <param name="defaultLoggerName">默认的日志文件名字</param>
        /// <returns>如果没异常，返回值就是正常返回值，假如出现了异常，返回值就是默认的值</returns>
        public static async Task<T> IgnoreButLogExceptionAsync<T>(Func<Task<T>> action, T defaultValue = default(T), [CallerMemberName] string memberName = null, string defaultLoggerName = null)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                ILogger logger = ObjectContainer.Current.Resolve<ILoggerFactory>().Create(defaultLoggerName ?? SysContant.LoggerName_Default);
                logger.Error(GetJsonErrorLog(ex, memberName: memberName));
                return defaultValue;
            }
        }

        #endregion 忽略异常，但记录异常

        #region 获取错误异常信息

        /// <summary>
        /// 获取错误异常信息
        /// </summary>
        /// <param name="ex">异常</param>
        /// <returns>错误异常信息</returns>
        public static string GetExceptionMsg(Exception ex, [CallerMemberName] string memberName = null)
        {
            StringBuilder errorBuilder = new StringBuilder();
            errorBuilder.AppendFormat("Source：{0}", ex.Source).AppendLine();
            errorBuilder.AppendFormat("StackTrace：{0}", ex.StackTrace).AppendLine();
            errorBuilder.AppendFormat("Message：{0}", ex.Message).AppendLine();
            if (ex.InnerException != null)
            {
                if (!string.Equals(ex.Message, ex.InnerException.Message, StringComparison.OrdinalIgnoreCase))
                {
                    errorBuilder.AppendFormat("InnerException：{0}", ex.InnerException.Message).AppendLine();
                }
            }
            if (!string.IsNullOrWhiteSpace(memberName))
            {
                errorBuilder.AppendFormat("CallerMemberName：{0}", memberName).AppendLine();
            }
            if (IsHaveHttpContext())
            {
                errorBuilder.AppendFormat("RealIP：{0}", GetRealIP()).AppendLine();
                errorBuilder.AppendFormat("HttpRequestUrl：{0}", GetHttpRequestUrl()).AppendLine();
                errorBuilder.AppendFormat("UserAgent：{0}", GetUserAgent()).AppendLine();
            }

            return errorBuilder.ToString();
        }

        #endregion 获取错误异常信息

        #region 获取错误日志的详情

        /// <summary>
        /// 获取错误日志的详情
        /// </summary>
        /// <param name="ex">错误异常</param>
        /// <param name="memberName">调用的成员名字</param>
        /// <returns>错误日志的详情</returns>
        public static LogDetailInfo GetErrorLog(Exception ex, [CallerMemberName] string memberName = null, string belongModule = null)
        {
            return LogDetailInfo.CreateErrorLog(GetExceptionMsg(ex, memberName: memberName),belongModule );
        }

        /// <summary>
        /// 获取Json格式的错误日志详情
        /// </summary>
        /// <param name="ex">错误异常</param>
        /// <param name="memberName">调用的成员名字</param>
        /// <returns>Json格式的错误日志详情</returns>
        public static string GetJsonErrorLog(Exception ex, [CallerMemberName] string memberName = null, string belongModule = null)
        {
            IJsonSerializer jsonSerializer = ObjectContainer.Current.Resolve<IJsonSerializer>();
            LogDetailInfo logDetailInfo = GetErrorLog(ex, memberName: memberName, belongModule: belongModule);
            return jsonSerializer.Serialize(logDetailInfo);
        }

        #endregion 获取错误日志的详情
    }
}