using LogMonitor.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/7 16:43:22
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Repository.EntityMap
{
    public sealed class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("T_User")
                .HasKey(m => m.FId);

            this.Property(m => m.FId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.FEmail)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsOptional();
            this.Property(m => m.FMobile)
                .IsOptional()
                .HasMaxLength(11)
                .IsUnicode(false);
            this.Property(m => m.FName)
                .IsUnicode(true)
                .HasMaxLength(50)
                .IsRequired();
            this.Property(m => m.FPwd)
                .IsUnicode(false)
                .HasMaxLength(32);
            this.Property(m => m.FSalt)
                .HasMaxLength(8)
                .IsUnicode(false);
            this.Property(m => m.FUserName)
                .IsUnicode(false)
                .HasMaxLength(50);
        }
    }
}