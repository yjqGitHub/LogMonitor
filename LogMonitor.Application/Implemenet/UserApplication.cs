﻿using LogMonitor.Application.Dtos;
using LogMonitor.Domain.Model;
using LogMonitor.IDomianService;
using LogMonitor.Infrastructure;
using LogMonitor.Infrastructure.Extension;
using LogMonitor.IRepository;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/19 16:57:46
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Application.Implemenet
{
    public sealed class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDomainService _userDomainService;

        public UserApplication(IUserRepository userRepository, IUserDomainService userDomainService)
        {
            _userRepository = userRepository;
            _userDomainService = userDomainService;
        }

        #region 登录

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public ValidationModel Login(string userName, string pwd)
        {
            try
            {
                User user = _userRepository.LoadEntities(m => m.FUserName == userName).FirstOrDefault();
                if (user == null)
                {
                    return new ValidationModel(OperateResultTypeEnum.Failes, "账号或密码错误");
                }
                _userDomainService.CheckPwd(user, pwd);
                Task loginTask = user.LoginAsync();
            }
            catch (ValidationException validateExp)
            {
                return new ValidationModel(OperateResultTypeEnum.Failes, validateExp.Message);
            }
            catch (Exception ex)
            {
                ILogger logger = ObjectContainer.Current.Resolve<ILoggerFactory>().Create(SysContant.LoggerName_Default);
                logger.Error(ex.ToErrorMsg(memberName: "Login"));
            }
            return new ValidationModel(OperateResultTypeEnum.Success, "登录成功");
        }

        #endregion 登录

        #region 获取用户列表

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="selectDto">用户查询条件传输对象</param>
        /// <returns>用户列表</returns>
        public PageResult<UserDto> GetUserList(UserSelectDto selectDto)
        {
            Expression<Func<User, bool>> whereLamda = _userDomainService.GetSelectWhereLamda(selectDto);
            return _userRepository.GetUserList(whereLamda, selectDto.SortColumn, selectDto.IsDesc).Select(m => new UserDto()
            {
                FAddTime = m.FAddTime,
                FIsAdmin = m.FIsAdmin,
                FEmail = m.FEmail,
                FId = m.FId,
                FIsDeleted = m.FIsDeleted,
                FMobile = m.FMobile,
                FModifyTime = m.FModifyTime,
                FName = m.FName,
                FUserName = m.FUserName
            }).ToPageList(selectDto.PageIndex, selectDto.PageSize);
        }

        #endregion 获取用户列表
    }
}