using LogMonitor.Domain;
using LogMonitor.Infrastructure;
using LogMonitor.Infrastructure.Extension;
using LogMonitor.IRepository;
using LogMonitor.Repository.DbManage;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 12:40:33
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository
{
    public partial class BaseRepository<T, TKey> : IBaseRepository<T, TKey> where T : class, IAggregateRoot<TKey>
    {
        #region private field

        private readonly IDbFactory _dbFactory;
        private LogMonitorContext _logMonitorContext;
        private readonly DbSet<T> _dbSet;

        #endregion private field

        #region .ctor

        public BaseRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _dbSet = LogMonitorContext.Set<T>();
        }

        #endregion .ctor

        protected LogMonitorContext LogMonitorContext
        {
            get { return _logMonitorContext ?? (_logMonitorContext = _dbFactory.GetLogMonitorContext()); }
        }

        #region 增删改

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        public void Add(T info)
        {
            Ensure.NotNull(info, "info");
            LogMonitorContext.Entry(info).State = EntityState.Added;
        }

        /// <summary>
        /// 用于已查询的实体
        /// </summary>
        /// <param name="info">已查询的实体</param>
        public void Update(T info)
        {
            LogMonitorContext.Entry(info).State = EntityState.Modified;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info"></param>
        /// <param name="updateProperties">要修改的字段</param>
        public void Update(T info, string[] updateProperties)
        {
            Ensure.NotNull(info, "info");
            Ensure.NotNull(updateProperties, "updateProperties");
            DbEntityEntry<T> entry = LogMonitorContext.Entry(info);
            entry.State = EntityState.Unchanged;
            updateProperties.ForEach(property =>
            {
                entry.Property(property).IsModified = true;
            });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="info"></param>
        public void Delete(T info)
        {
            Ensure.NotNull(info, "info");
            LogMonitorContext.Entry(info).State = EntityState.Deleted;
        }

        #endregion 增删改

        #region 查询

        /// <summary>
        /// 根据主键值获取
        /// </summary>
        /// <param name="key">主键的值</param>
        /// <param name="autoDetectChangesEnabled">是否跟踪实体（True:跟踪,False:不跟踪）</param>
        /// <returns></returns>
        public T GetByKey(TKey key, bool autoDetectChangesEnabled = false)
        {
            T entity;
            bool autoState = LogMonitorContext.Configuration.AutoDetectChangesEnabled;
            try
            {
                LogMonitorContext.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
                entity = _dbSet.Find(key);
            }
            finally
            {
                LogMonitorContext.Configuration.AutoDetectChangesEnabled = autoState;
            }
            return entity;
        }

        /// <summary>
        /// 获取全部实体
        /// </summary>
        /// <param name="autoDetectChangesEnabled">是否跟踪实体（True:跟踪,False:不跟踪）</param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(bool autoDetectChangesEnabled = false)
        {
            return autoDetectChangesEnabled ? _dbSet : _dbSet.AsNoTracking();
        }

        /// <summary>
        /// 根据条件获取
        /// </summary>
        /// <param name="whereLamda">要获取的条件</param>
        /// <param name="autoDetectChangesEnabled"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLamda, bool autoDetectChangesEnabled = false)
        {
            var queryList = _dbSet.Where(whereLamda);
            return autoDetectChangesEnabled ? queryList : queryList.AsNoTracking();
        }

        /// <summary>
        /// 根据条件查询并进行排序
        /// </summary>
        /// <typeparam name="S">排序字段</typeparam>
        /// <param name="whereLamda">查询条件</param>
        /// <param name="orderLamda">排序条件</param>
        /// <param name="isDesc">是否倒序排列</param>
        /// <param name="autoDetectChangesEnabled">是否跟踪实体（True:跟踪,False:不跟踪）</param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities<S>(Expression<Func<T, bool>> whereLamda, Expression<Func<T, S>> orderLamda, bool isDesc, bool autoDetectChangesEnabled = false)
        {
            var queryList = _dbSet.Where(whereLamda);
            if (isDesc)
                queryList = queryList.OrderByDescending(orderLamda);
            else
                queryList = queryList.OrderBy(orderLamda);
            return autoDetectChangesEnabled ? queryList : queryList.AsNoTracking();
        }

        #endregion 查询
    }
}