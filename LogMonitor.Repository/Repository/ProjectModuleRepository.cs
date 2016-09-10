using LogMonitor.Domain.Model;
using LogMonitor.IRepository;
using LogMonitor.Repository.DbManage;
using System.Data.SqlClient;
using System.Linq;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/10 14:01:12
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.Repository
{
    public sealed class ProjectModuleRepository : BaseRepository<ProjectModule, int>, IProjectModuleRepository
    {
        public ProjectModuleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        #region 根据模块名称查询模块信息(负责人信息)

        /// <summary>
        /// 根据模块代码查询模块信息(负责人信息)
        /// </summary>
        /// <param name="moduleCode">模块代码</param>
        /// <param name="projectCode">项目代码</param>
        /// <returns>模块信息(负责人信息)</returns>
        public ProjectModule GetProjectModule(string moduleCode, string projectCode)
        {
            string selectSql = "SELECT A.FId,A.FProjectId,A.FModuleName,A.FModuleCode,A.FDescription,A.FIsDeleted,A.FCreater,A.FAddTime,A.FModifyTime,B.FIsManager IsManager,C.FId MemberId,C.FName MemberName,C.FEmail MemberEmail,C.FMobile MemberMobile FROM T_Project_Module A LEFT JOIN T_Module_Person B ON A.FId = B.FModuleId LEFT JOIN T_User C ON C.FId = B.FUserId AND C.FIsDeleted = 0  JOIN T_Project D ON D.FId=A.FProjectId WHERE A.FModuleCode =@FModuleCode AND A.FIsDeleted = 0  AND D.FProjectCode=@FProjectCode;";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter() { ParameterName="@FModuleCode",Value=moduleCode,Size=50,SqlDbType= System.Data.SqlDbType.VarChar },
                new SqlParameter() { ParameterName="@FProjectCode",Value=projectCode,Size=50,SqlDbType= System.Data.SqlDbType.VarChar }
            };
            return this.LogMonitorContext.Database.SqlQuery<ProjectModule>(selectSql, paras).FirstOrDefault();
        }

        #endregion 根据模块名称查询模块信息(负责人信息)
    }
}