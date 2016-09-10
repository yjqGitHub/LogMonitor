using LogMonitor.Domain.Model;
using System.Data.Entity.ModelConfiguration;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 17:59:52
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.EntityMap
{
    public sealed class ProjectMap : EntityTypeConfiguration<Project>
    {
        public ProjectMap()
        {
            this.ToTable("T_Project")
                .HasKey(m => m.FId);
            this.Property(M => M.FId)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(m => m.FDescription)
                .IsUnicode(true)
                .HasMaxLength(80)
                .IsOptional();
            this.Property(m => m.FProjectCode)
                .IsUnicode(false)
                .IsOptional()
                .HasMaxLength(50);
            this.Property(m => m.FProjectName)
                .IsUnicode(true)
                .IsOptional()
                .HasMaxLength(50);

            this.Ignore(m => m.Members);
        }
    }
}