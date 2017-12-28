using Cosmetic.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.Bussiness.DTO
{
     public class CategoryDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public bool Status { get; set; }
        
    }
}
