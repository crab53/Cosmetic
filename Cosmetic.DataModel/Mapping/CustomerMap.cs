using Cosmetic.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Mapping
{
   public class CustomerMap: EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.ToTable("Customer");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasMaxLength(100);
            this.Property(x => x.Name).IsRequired().HasMaxLength(255);
            this.Property(x => x.Phone).HasMaxLength(100);
            this.Property(x => x.Email).IsRequired().HasMaxLength(255);
            this.Property(x => x.City).HasMaxLength(100);
            this.Property(x => x.Country).HasMaxLength(100);
            this.Property(x => x.Active).IsRequired();
            
        }
    }
}
