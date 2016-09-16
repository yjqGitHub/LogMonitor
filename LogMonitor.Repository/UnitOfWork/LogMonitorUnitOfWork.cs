using LogMonitor.IUnitOfWork;
using LogMonitor.Repository.DbManage;
using System;
using System.Data.Entity.Validation;
using System.Threading.Tasks;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 12:04:28
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.UnitOfWork
{
    public sealed class LogMonitorUnitOfWork : ILogMonitorUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private LogMonitorContext _dataContext;

        public LogMonitorUnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;

        }

        private LogMonitorContext DataContext
        {
            get
            {
                return _dataContext ?? (_dataContext = _dbFactory.GetLogMonitorContext());
            }
        }
        public bool Commit()
        {
            try
            {
                return DataContext.SaveChanges() > 0;
            }
            catch (DbEntityValidationException dbEx)
            {
                throw GetDbEntityValidationExceptionMseeage(dbEx);
            }
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                return await DataContext.SaveChangesAsync() > 0;
            }
            catch (DbEntityValidationException dbEx)
            {
                throw GetDbEntityValidationExceptionMseeage(dbEx);
            }
        }

        private Exception GetDbEntityValidationExceptionMseeage(DbEntityValidationException dbEx)
        {
            var msg = string.Empty;
            foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
            var fail = new Exception(msg, dbEx);
            return fail;
        }
    }
}