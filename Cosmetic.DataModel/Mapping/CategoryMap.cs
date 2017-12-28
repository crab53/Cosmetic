using Cosmetic.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Mapping
{
   public class CategoryMap: EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("Category");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasMaxLength(100);
            this.Property(x => x.Name).IsRequired().HasMaxLength(255);
            this.Property(x => x.ParentId).IsRequired().HasMaxLength(100);            
        }
    }
}
