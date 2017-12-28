using Cosmetic.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Mapping
{
   public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("User");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasMaxLength(100);
            this.Property(x => x.Name).IsRequired().HasMaxLength(255);
            this.Property(x => x.Email).IsRequired().HasMaxLength(255);
            this.Property(x => x.Password).IsRequired().HasMaxLength(255);
            this.Property(x => x.CreatedDate).IsRequired();
            this.Property(x => x.CreatedUser).IsRequired().HasMaxLength(255);
            this.Property(x => x.LastDateModified).IsRequired();
            this.Property(x => x.LastUserModified).IsRequired().HasMaxLength(255);
            this.Property(x => x.IsActive).IsRequired();
        }
    }
}
