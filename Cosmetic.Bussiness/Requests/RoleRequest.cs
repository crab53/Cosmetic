using Cosmetic.Core.Request;
using Cosmetic.DataModel.Entities;

namespace Cosmetic.Bussiness.Requests
{
    public class RoleRequest: RequestModelBase
    {
        public Role Role { get; set; }
    }
}
