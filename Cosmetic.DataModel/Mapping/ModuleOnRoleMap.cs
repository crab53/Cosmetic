using Cosmetic.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Mapping
{
   public class ModuleOnRoleMap: EntityTypeConfiguration<ModulesOnRole>
    {
        public ModuleOnRoleMap()
        {
            this.ToTable("ModulesOnRole");
            this.HasKey(aa => aa.Id);
            this.Property(aa => aa.Id).HasMaxLength(100);
            this.Property(aa => aa.RoleID).IsRequired().HasMaxLength(100);
            this.Property(aa => aa.ModuleID).HasMaxLength(100).IsRequired();
            this.Property(aa => aa.ModuleParentID).HasMaxLength(100);
            this.Property(aa => aa.IsAction).IsRequired();
            this.Property(aa => aa.IsActive).IsRequired();
            this.Property(aa => aa.IsView).IsRequired();
            this.Property(aa => aa.CreatedDate).IsRequired();
            this.Property(aa => aa.CreatedUser).IsRequired().HasMaxLength(255);
            this.Property(aa => aa.ModifiedDate).IsRequired();
            this.Property(aa => aa.ModifiedUser).IsRequired().HasMaxLength(255);
        }
    }
}
