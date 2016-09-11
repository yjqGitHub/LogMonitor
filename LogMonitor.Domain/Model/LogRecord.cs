using LogMonitor.Domain.DomainEvent;
using LogMonitor.Domain.ValueObject;
using LogMonitor.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 9:42:43
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Domain.Model
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public sealed class LogRecord : IAggregateRoot<long>
    {
        /// <summary>
        /// 主Id，自增
        /// </summary>
        public long FId { get; set; }

        /// <summary>
        /// 日志类型(枚举)
        /// </summary>
        public LogTypeEnum FLogType { get; set; }

        /// <summary>
        /// 程序名字
        /// </summary>
        public string FAppDomain { get; set; }

        /// <summary>
        /// 项目Id
        /// </summary>
        public int? FProjectId { get; set; }

        /// <summary>
        /// 项目代码
        /// </summary>
        public string FProjectCode { get; set; }

        /// <summary>
        /// 模块Id
        /// </summary>
        public int? FModuleId { get; set; }

        /// <summary>
        /// 模块代码
        /// </summary>
        public string FModuleCode { get; set; }

        /// <summary>
        /// 日志信息
        /// </summary>
        public string FMessage { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime FCreateTime { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime FAddTime { get; set; }

        /// <summary>
        /// 是否已通知
        /// </summary>
        public bool FIsNoticed { get; set; }

        /// <summary>
        /// 负责人列表
        /// </summary>
        public List<MemberInfo> Chargers { get; set; }

        #region 设置项目模块信息

        /// <summary>
        /// 设置项目模块信息
        /// </summary>
        /// <param name="projectModule">项目模块信息</param>
        public void SetModuleInfo(ProjectModule projectModule)
        {
            if (projectModule != null)
            {
                FModuleId = projectModule.FId;
                FProjectId = projectModule.FProjectId;
                if (projectModule.Members != null)
                {
                    AddCharges(projectModule.Members.ToList());
                }
            }
        }

        #endregion 设置项目模块信息

        #region 设置项目信息

        /// <summary>
        /// 设置项目信息
        /// </summary>
        /// <param name="project">项目信息</param>
        public void SetProjectInfo(Project project)
        {
            if (project != null)
            {
                FProjectId = project.FId;
                if (project.Members != null)
                {
                    AddCharges(project.Members.ToList());
                }
            }
        }

        #endregion 设置项目信息

        #region 添加负责人列表

        /// <summary>
        /// 添加负责人列表
        /// </summary>
        /// <param name="memberList">负责人列表</param>
        public void AddCharges(List<MemberInfo> memberList)
        {
            if (memberList != null)
                Chargers.AddRange(memberList);
        }

        /// <summary>
        /// 添加负责人
        /// </summary>
        /// <param name="member">负责人</param>
        public void AddCharge(MemberInfo member)
        {
            if (member != null)
                Chargers.Add(member);
        }

        /// <summary>
        /// 添加负责人列表
        /// </summary>
        /// <param name="userList">用户列表</param>
        public void AddCharges(List<User> userList)
        {
            AddCharges(userList.Select(m => new MemberInfo()
            {
                IsManager = m.FIsAdmin,
                MemberEmail = m.FEmail,
                MemberId = m.FId,
                MemberMobile = m.FMobile,
                MemberName = m.FName
            }).ToList());
        }

        #endregion 添加负责人列表

        #region 有新日志记录产生时处理方式

        /// <summary>
        /// 有新日志记录产生时处理方式
        /// </summary>
        /// <returns></returns>
        public async Task HaveNewRecordAsync([CallerMemberName] string memberName = null, string defaultLoggerName = null)
        {
            switch (FLogType)
            {
                case LogTypeEnum.Error:
                    await SendDangerLogHappendEventAsync($"【{FProjectCode}】项目有错误发生,请前去查看", FMessage, memberName: memberName, defaultLoggerName: defaultLoggerName);
                    break;

                case LogTypeEnum.Fatal:
                    await SendDangerLogHappendEventAsync($"【{FProjectCode}】项目有严重事情要处理,请前去查看", FMessage, memberName: memberName, defaultLoggerName: defaultLoggerName);
                    break;

                case LogTypeEnum.Warning:
                    await SendDangerLogHappendEventAsync($"【{FProjectCode}】项目有警告事件,请前去查看", FMessage, memberName: memberName, defaultLoggerName: defaultLoggerName);
                    break;
            }
        }

        #endregion 有新日志记录产生时处理方式

        #region 发送危险日志发生事件

        /// <summary>
        /// 发送危险日志发生事件
        /// </summary>
        /// <param name="title">发送标题</param>
        /// <param name="message">发送内容</param>
        /// <returns></returns>
        private async Task SendDangerLogHappendEventAsync(string title, string message, [CallerMemberName] string memberName = null, string defaultLoggerName = null)
        {
            await ExceptionHelper.IgnoreButLogExceptionAsync(async () =>
           {
               IEventBus eventBus = ObjectContainer.Current.Resolve<IEventBus>();
               DangerLogHappendEvent dangerLogHappendEvent = new DangerLogHappendEvent()
               {
                   ReceiverEmailList = Chargers?.Select(m => m.MemberEmail).ToArray(),
                   Title = title,
                   Message = message
               };
               await eventBus.PublishAsync(dangerLogHappendEvent);
           }, memberName: memberName, defaultLoggerName: defaultLoggerName);
        }

        #endregion 发送危险日志发生事件
    }
}