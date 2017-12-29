using Cosmetic.Bussiness.DTO;
using Cosmetic.Bussiness.Requests;
using Cosmetic.Bussiness.Responses;
using Cosmetic.Core.Request;
using Cosmetic.Core.Response;
using Cosmetic.DataModel;
using Cosmetic.DataModel.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmetic.Bussiness.Bussiness
{
    public class CosBusCustomer
    {
        protected static CosBusCustomer _instance;
        public static CosBusCustomer Instance
        {
            get
            {
                _instance = _instance != null ? _instance : new CosBusCustomer();
                return _instance;
            }
        }
        static CosBusCustomer() { }
        // CreateUpdateCustomer
        public async Task<CosApiResponse> CreateUpdateCustomer(CustomerRequest request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    var customer = request.Customer;
                    if (string.IsNullOrEmpty(customer.Id)) /* insert */
                    {
                        customer.Id = Guid.NewGuid().ToString();
                        var customerDB = new Customer()
                        {
                            Id = customer.Id,
                            Name = customer.Name,
                            Email = customer.Email,                            
                            City = customer.City,

                        };
                        _db.Customers.Add(customerDB);
                    }
                    else /* update */
                    {
                        var customerDB = _db.Customers.Where(o => o.Id == customer.Id).FirstOrDefault();
                        customerDB.Name = customer.Name;
                        customerDB.Email = customer.Email;
                        customerDB.City = customer.City;
                    }

                    /* save data */
                    if (_db.SaveChanges() > 0)
                        response.Success = true;
                    else
                        response.Message = "Unable to add new or update customer";
                    NSLog.Logger.Info("Response Create Update customer", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Create Update customer", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Delete Customer
        public async Task<CosApiResponse> DeleteCustomer(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    /* delete */
                    var customerDB = _db.Customers.Where(o => o.Id == request.ID /*&& o.Status == Constants.Estatus.Active*/ ).FirstOrDefault();
                    if (customerDB != null)
                    {
                        //proDB.Status = Constants.EStatus.Deleted;

                        /* Save change data */
                        if (_db.SaveChanges() > 0)
                            response.Success = true;
                        else
                            response.Message = "Unable to delete customer";
                    }
                    else
                        response.Message = "Unable to find customer";
                    NSLog.Logger.Info("Response Delete customer", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Delete customer", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Get Detail Customer
        public async Task<CosApiResponse> GetDetailCustomer(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    GetDetailCustomerResponse result = new GetDetailCustomerResponse();

                    /* get Customer */
                    var customerDB = _db.Customers.Where(o => o.Id == request.ID /*&& o.Status == Constants.Estatus.Active*/ ).FirstOrDefault();
                    if (customerDB != null)
                    {
                        var responseUser = new CustomersDTO()
                        {
                            Id = customerDB.Id,
                            Name = customerDB.Name,
                            Email = customerDB.Email,                            
                            Phone = customerDB.Phone,
                            Active = customerDB.Active,
                           City = customerDB.City,
                           Country = customerDB.Country,
                           
                        };
                        result.Customer = responseUser;
                        response.Data = result;
                    }
                    else
                        response.Message = "Unable to find customer";

                    NSLog.Logger.Info("Response Get Detail customer", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Get Detail customer", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        //Get List Customer
        public async Task<CosApiResponse> GetListCustomer(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    GetListCustomerResponse result = new GetListCustomerResponse();

                    /* get Customer */
                    var query = _db.Customers.Where(o => true/* o.Status == Constants.EStatus.Actived*/);

                    result.ListCustomer = query.Select(o => new CustomersDTO()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Email = o.Email,
                        Country= o.Country,
                        Phone = o.Phone,
                        Active = o.Active,
                        City = o.City,
                    }).ToList();

                    /* response data  */
                    response.Data = result;

                    NSLog.Logger.Info("Response Get List customer", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Get List customer", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
    }
}
