namespace Cosmetic.DataModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Price")]
    public partial class ProductPrice
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime FromDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductID { get; set; }

        public int Status { get; set; }

        public virtual Product Product { get; set; }
    }
}
