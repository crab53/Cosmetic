using Cosmetic.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Mapping
{
   public class OrderMap: EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.ToTable("Order");
            this.HasKey(aa => aa.Id);
            this.Property(aa => aa.Id).HasMaxLength(100);
            this.Property(aa => aa.OrderNo).IsRequired().HasMaxLength(255);
            this.Property(aa => aa.ReceiptNo).HasMaxLength(255).IsRequired();
            this.Property(aa => aa.CustomerId).IsRequired().HasMaxLength(100);
            this.Property(aa => aa.TotalBil);
            this.Property(aa => aa.Discount);            
        }
    }
}
