using LogMonitor.Domain.Model;
using System.Data.Entity.ModelConfiguration;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 9:49:07
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.EntityMap
{
    public sealed class ProjectModuleMap : EntityTypeConfiguration<ProjectModule>
    {
        public ProjectModuleMap()
        {
            this.ToTable("T_Project_Module")
                .HasKey(m => m.FId);
            this.Property(m => m.FId)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(m => m.FDescription)
                .IsUnicode(true)
                .HasMaxLength(80)
                .IsOptional();
            this.Property(m => m.FModuleCode)
                .IsUnicode(false)
                .HasMaxLength(50);
            this.Property(m => m.FModuleName)
                .IsUnicode(true)
                .HasMaxLength(50)
                .IsOptional();

            this.Ignore(m => m.Members);
        }
    }
}