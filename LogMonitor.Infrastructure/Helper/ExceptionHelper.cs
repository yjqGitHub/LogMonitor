using LogMonitor.Infrastructure.Extension;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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
                logger.Error(ex.ToErrorMsg(memberName: memberName));
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
                logger.Error(ex.ToErrorMsg(memberName: memberName));
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
                logger.Error(ex.ToErrorMsg(memberName: memberName));
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
                logger.Error(ex.ToErrorMsg(memberName: memberName));
                return defaultValue;
            }
        }

        #endregion 忽略异常，但记录异常
    }
}