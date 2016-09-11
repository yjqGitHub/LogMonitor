using LogMonitor.Domain.Model;
using LogMonitor.IRepository;
using LogMonitor.Repository.DbManage;
using System.Data.SqlClient;
using System.Linq;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/10 10:33:34
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.Repository
{
    public sealed class ProjectRepository : BaseRepository<Project, int>, IProjectRepository
    {
        public ProjectRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        #region 根据项目代码获取项目信息

        /// <summary>
        /// 根据项目代码获取项目信息
        /// </summary>
        /// <param name="projectCode">项目代码</param>
        /// <returns>项目信息</returns>
        public Project GetProjectInfo(string projectCode)
        {
            string selectSql = " SELECT A.FId,A.FProjectName,A.FProjectCode,A.FDescription,A.FIsDeleted,A.FCreater,A.FAddTime,A.FModifyTime,B.FIsManager IsManager,C.FId MemberId,C.FName MemberName,C.FEmail MemberEmail,C.FMobile MemberMobile FROM T_Project A LEFT JOIN T_Project_Person B ON A.FId=B.FProjectId AND B.FIsDeleted=0 LEFT JOIN T_User C ON C.FId=B.FUserId  WHERE A.FProjectCode=@FProjectCode AND A.FIsDeleted=0";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter() { ParameterName="@FProjectCode",Value=projectCode,Size=50,SqlDbType= System.Data.SqlDbType.VarChar }
            };
            return this.LogMonitorContext.Database.SqlQuery<Project>(selectSql, paras).FirstOrDefault();
        }

        #endregion 根据项目代码获取项目信息
    }
}