using Cosmetic.Core.Request;
using Cosmetic.DataModel.Model;

namespace Cosmetic.Bussiness.Requests
{
    public class UserRequest: RequestModelBase
    {
        public User User { get; set; }
    }
}
