using LogMonitor.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 18:05:10
* Class Version       :    v1.0.0.0
* Class Description   :    
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.EntityMap
{
    public sealed class ErrorLogRecordMap:EntityTypeConfiguration<ErrorLogRecord>
    {
        public ErrorLogRecordMap()
        {
            this.ToTable("T_ErrorLogRecord")
                .HasKey(m => m.FId);
            this.Property(m => m.FId)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(m => m.FAppDomain)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
        }
    }
}
