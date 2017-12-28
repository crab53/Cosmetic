using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Entities
{
   public class User: BaseEntities
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public string LastUserModified { get; set; }
        public DateTime LastDateModified { get; set; }
        public string RoleID { get; set; }
        public virtual Role Roles { get; set; }

    }
}
