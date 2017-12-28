using Cosmetic.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Mapping
{
   public class ProductMap: EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            this.ToTable("Product");
            this.HasKey(aa => aa.Id);
            this.Property(aa => aa.Id).HasMaxLength(100);            
            this.Property(aa => aa.Name).HasMaxLength(255).IsRequired();
            this.Property(aa => aa.CategoryId).IsRequired().HasMaxLength(100);
            this.Property(aa => aa.Price).IsRequired();            
        }
    }
}
