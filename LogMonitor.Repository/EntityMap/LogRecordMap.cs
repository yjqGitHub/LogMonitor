using LogMonitor.Domain.Model;
using System.Data.Entity.ModelConfiguration;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 10:08:14
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.EntityMap
{
    public sealed class LogRecordMap : EntityTypeConfiguration<LogRecord>
    {
        public LogRecordMap()
        {
            this.ToTable("T_LogRecord")
                .HasKey(m => m.FId);
            this.Property(m => m.FId)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(m => m.FAppDomain)
                .IsUnicode(false)
                .HasMaxLength(200);
            this.Property(m => m.FMessage)
                .IsUnicode(true);
            this.Property(m => m.FModuleCode)
                .IsUnicode(false)
                .HasMaxLength(50);
            this.Property(m => m.FProjectCode)
                .IsUnicode(false)
                .HasMaxLength(50);

            this.Ignore(m => m.Chargers);
        }
    }
}