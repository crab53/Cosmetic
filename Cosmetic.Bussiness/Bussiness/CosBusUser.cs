using Cosmetic.Bussiness.DTO;
using Cosmetic.Bussiness.Requests;
using Cosmetic.Bussiness.Responses;
using Cosmetic.Core.Request;
using Cosmetic.Core.Response;
using Cosmetic.DataModel;
using Cosmetic.DataModel.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmetic.Bussiness.Bussiness
{
    public class CosBusUser : CosBusBase
    {
        protected static CosBusUser _instance;
        public static CosBusUser Instance
        {
            get
            {
                _instance = _instance != null ? _instance : new CosBusUser();
                return _instance;
            }
        }
        static CosBusUser() { }
        // Create Or Update User
        public async Task<CosApiResponse> CreateUpdateUser(UserRequest request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosmeticsContext())
                {
                    var user = request.User;
                    if (string.IsNullOrEmpty(user.Id)) /* insert */
                    {
                        user.Id = Guid.NewGuid().ToString();
                        var userDB = new User()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Email = user.Email,
                            Password = user.Password,

                        };
                        _db.Users.Add(userDB);
                    }
                    else /* update */
                    {
                        var userDB = _db.Users.Where(o => o.Id == user.Id).FirstOrDefault();
                        userDB.Name = user.Name;
                        userDB.Email = user.Email;
                        userDB.Password = user.Password;
                    }

                    /* save data */
                    if (_db.SaveChanges() > 0)
                        response.Success = true;
                    else
                        response.Message = "Unable to add new or update User.";
                    NSLog.Logger.Info("Response Create Update User", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Create Update User", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Delete User
        public async Task<CosApiResponse> DeleteUser(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosmeticsContext())
                {
                    /* delete */
                    var UserDB = _db.Users.Where(o => o.Id == request.ID /*&& o.Status == Constants.Estatus.Active*/ ).FirstOrDefault();
                    if (UserDB != null)
                    {
                        /* Save change data */
                        if (_db.SaveChanges() > 0)
                            response.Success = true;
                        else
                            response.Message = "Unable to delete User";
                    }
                    else
                        response.Message = "Unable to find Users";
                    NSLog.Logger.Info("Response Delete Users", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Delete Users", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Get Detail User
        public async Task<CosApiResponse> GetDetailUser(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosmeticsContext())
                {
                    GetDetailUserResponse result = new GetDetailUserResponse();

                    /* get User */
                    var UserDB = _db.Users.Where(o => o.Id == request.ID /*&& o.Status == Constants.Estatus.Active*/ ).FirstOrDefault();
                    if (UserDB != null)
                    {
                        var responseUser = new UserDTO()
                        {
                            Id = UserDB.Id,
                            Name = UserDB.Name,
                            Email = UserDB.Email,
                            Password = UserDB.Password,
                            Phone = UserDB.Phone,
                            Active = UserDB.IsActive,
                            RoleId = UserDB.RoleID,
                        };
                        result.User = responseUser;
                        response.Data = result;
                    }
                    else
                        response.Message = "Unable to find User";

                    NSLog.Logger.Info("Response Get Detail User", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Get Detail User", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Get List User
        public async Task<CosApiResponse> GetListUser(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosmeticsContext())
                {
                    GetListUserResponse result = new GetListUserResponse();

                    /* get User */
                    var query = _db.Users.Where(o => true/* o.Status == Constants.EStatus.Actived*/);

                    result.ListUser = query.Select(o => new UserDTO()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Email = o.Email,
                        Password = o.Password,
                        Phone = o.Phone,
                        Active = o.IsActive,
                        RoleId = o.RoleID,
                    }).ToList();

                    /* response data  */
                    response.Data = result;

                    NSLog.Logger.Info("Response Get List Users", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Get List Users", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
    }
}
