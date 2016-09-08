using LogMonitor.Domain.Model;
using LogMonitor.Infrastructure.Extension;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 16:14:42
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository
{
    public sealed class LogMonitorContext : DbContext
    {
        public LogMonitorContext() : base("LogMonitor")
        {
            Database.SetInitializer<LogMonitorContext>(null);
        }

        /// <summary>
        /// 浏览记录
        /// </summary>
        public DbSet<BrowseLogRecord> BrowseLogRecords { get; set; }

        /// <summary>
        /// 日志记录
        /// </summary>
        public DbSet<LogRecord> LogRecords { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// 项目模块
        /// </summary>
        public DbSet<ProjectModule> ProjectModules { get; set; }

        /// <summary>
        /// 项目模块人员
        /// </summary>
        public DbSet<ProjectModulePerson> ProjectModulePersons { get; set; }

        /// <summary>
        /// 项目人员关系
        /// </summary>
        public DbSet<ProjectPerson> ProjectPersons { get; set; }

        /// <summary>
        /// 人员
        /// </summary>
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //用于将级联删除从多对多关系中涉及的两个表添加到联接表的约定。
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //提供用于为任何必需关系启用级联删除的约定。
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //表示用于将实体集名称设置为实体类型名称的复数版本的约定。
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            //表示用于将表名称设置为实体类型名称的复数版本的约定。
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var typeRegisters = from type in Assembly.GetExecutingAssembly().GetTypes()
                                where
                                type.FullName.StartsWith("LogMonitor.Repository.EntityMap")
                                &&
                                type.BaseType != null
                                &&
                                type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)
                                select type;
            typeRegisters.ForEach(type =>
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}