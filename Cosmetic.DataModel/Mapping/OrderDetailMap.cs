using Cosmetic.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Mapping
{
   public class OrderDetailMap: EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            this.ToTable("OrderDetail");
            this.HasKey(aa => aa.Id);
            this.Property(aa => aa.Id).HasMaxLength(100);
            this.Property(aa => aa.ProductId).IsRequired().HasMaxLength(100);           
            this.Property(aa => aa.OrderId).IsRequired().HasMaxLength(100);
            this.Property(aa => aa.Price).IsRequired();
            this.Property(aa => aa.Quantity);            
        }
    }
}
