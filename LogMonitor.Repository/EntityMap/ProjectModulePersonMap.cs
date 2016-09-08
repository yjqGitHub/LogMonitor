using LogMonitor.Domain.Model;
using System.Data.Entity.ModelConfiguration;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/8 9:53:06
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.EntityMap
{
    public sealed class ProjectModulePersonMap : EntityTypeConfiguration<ProjectModulePerson>
    {
        public ProjectModulePersonMap()
        {
            this.ToTable("T_Module_Person")
                .HasKey(m => m.FId);
            this.Property(m => m.FId)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}