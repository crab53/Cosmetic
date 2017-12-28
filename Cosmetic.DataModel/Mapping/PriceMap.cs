using Cosmetic.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Mapping
{
   public class PriceMap: EntityTypeConfiguration<Price>
    {
        public PriceMap()
        {
            this.ToTable("Price");
            this.HasKey(aa => aa.Id);
            this.Property(aa => aa.Id).HasMaxLength(100);
            this.Property(aa => aa.Prices).IsRequired();
            this.Property(aa => aa.ToDate).IsRequired();
            this.Property(aa => aa.FromDate).IsRequired();
            this.Property(aa => aa.ProductId).IsRequired().HasMaxLength(100);            
        }
    }
}
