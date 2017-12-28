using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.DataModel.Entities
{
    public abstract class BaseEntities
    {
        public string Id { get; set; }        
        public int Status { get; set; }
    }
}
