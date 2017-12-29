namespace Cosmetic.DataModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModulesOnRole")]
    public partial class ModulesOnRole
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string ModulesId { get; set; }

        public bool IsView { get; set; }

        public bool IsAction { get; set; }

        public int Status { get; set; }

        public bool Active { get; set; }

        public virtual Module Module { get; set; }

        public virtual Role Role { get; set; }
    }
}
