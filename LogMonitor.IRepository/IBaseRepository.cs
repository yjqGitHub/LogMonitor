using LogMonitor.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 16:09:44
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.IRepository
{
    public interface IBaseRepository<T, TKey> where T : IAggregateRoot<TKey>
    {
        #region 增删改

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info">要添加的实体信息</param>
        void Add(T info);

        /// <summary>
        /// 用于已查询的实体
        /// </summary>
        /// <param name="info">已查询的实体</param>
        void Update(T info);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info"></param>
        /// <param name="updateProperties">需要修改的字段</param>
        void Update(T info, string[] updateProperties);

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="info"></param>
        void Delete(T info);

        #endregion 增删改

        #region 查询

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="key">主键值</param>
        /// <param name="autoDetectChangesEnabled">是否跟踪实体（True:跟踪,False:不跟踪）</param>
        /// <returns>实体</returns>
        T GetByKey(TKey key, bool autoDetectChangesEnabled = false);

        /// <summary>
        /// 加载全部
        /// </summary>
        /// <param name="autoDetectChangesEnabled">是否跟踪实体（True:跟踪,False:不跟踪）</param>
        /// <returns>全部数据</returns>
        IQueryable<T> LoadEntities(bool autoDetectChangesEnabled = false);

        /// <summary>
        /// 根据条件查询符合的数据
        /// </summary>
        /// <param name="whereLamda">条件</param>
        /// <param name="autoDetectChangesEnabled">是否跟踪实体（True:跟踪,False:不跟踪）</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLamda, bool autoDetectChangesEnabled = false);

        /// <summary>
        /// 根据条件查询并进行排序
        /// </summary>
        /// <typeparam name="S">排序字段</typeparam>
        /// <param name="whereLamda">查询条件</param>
        /// <param name="orderLamda">排序条件</param>
        /// <param name="isDesc">是否倒序排列</param>
        /// <param name="autoDetectChangesEnabled">是否跟踪实体（True:跟踪,False:不跟踪）</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities<S>(Expression<Func<T, bool>> whereLamda, Expression<Func<T, S>> orderLamda, bool isDesc, bool autoDetectChangesEnabled = false);

        #endregion 查询
    }
}