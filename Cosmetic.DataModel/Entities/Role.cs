using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Entities
{
    public class Role: BaseEntities
    {      
        public string ModuleId { get; set; }
        public int RoleLevel { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
