using LogMonitor.Domain.Model;
using System.Data.Entity.ModelConfiguration;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 9:57:42
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.EntityMap
{
    public sealed class BrowseLogRecordMap : EntityTypeConfiguration<BrowseLogRecord>
    {
        public BrowseLogRecordMap()
        {
            this.ToTable("T_BrowseLogRecord")
                .HasKey(m => m.FId);
            this.Property(m => m.FId)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(m => m.FAbsoluteUrl)
                .HasMaxLength(100)
                .IsUnicode(false);
            this.Property(m => m.FAppDomain)
                .IsUnicode(false)
                .HasMaxLength(200);
            this.Property(m => m.FIpAddress)
                .IsUnicode(true)
                .HasMaxLength(50);
            this.Property(m => m.FMessage)
                .IsUnicode(false)
                .HasMaxLength(150);
            this.Property(m => m.FProjectCode)
                .IsUnicode(false)
                .HasMaxLength(50);
            this.Property(m => m.FQueryUrl)
                .IsUnicode(false)
                .HasMaxLength(400);
            this.Property(m => m.FRequestIp)
                .IsUnicode(false)
                .HasMaxLength(15);
            this.Property(m => m.FRequestType)
                .IsUnicode(false)
                .HasMaxLength(20);
            this.Property(m => m.FUserAgent)
                .IsUnicode(false)
                .HasMaxLength(200);
        }
    }
}