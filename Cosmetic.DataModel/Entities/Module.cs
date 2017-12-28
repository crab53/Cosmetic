using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Entities
{
    public class Modules : BaseEntities
    {

        public string Name { get; set; }
        public string ParentID { get; set; }
        public string Controller { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int? IndexNum { get; set; }
        public virtual ICollection<ModulesOnRole> ModulesOnRoles { get; set; }
    }
}
