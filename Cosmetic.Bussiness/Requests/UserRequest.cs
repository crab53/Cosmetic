using Cosmetic.Core.Request;
using Cosmetic.DataModel.Entities;

namespace Cosmetic.Bussiness.Requests
{
    public class UserRequest: RequestModelBase
    {
        public User User { get; set; }
    }
}
