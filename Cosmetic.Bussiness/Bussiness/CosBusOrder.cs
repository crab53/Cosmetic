using Cosmetic.Bussiness.DTO;
using Cosmetic.Bussiness.Requests;
using Cosmetic.Bussiness.Responses;
using Cosmetic.Core.Common;
using Cosmetic.Core.Request;
using Cosmetic.Core.Response;
using Cosmetic.DataModel;
using Cosmetic.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.Bussiness.Bussiness
{
    public class CosBusOrder
    {
        protected static CosBusOrder _instance;
        public static CosBusOrder Instance
        {
            get
            {
                _instance = _instance != null ? _instance : new CosBusOrder();
                return _instance;
            }
        }
        static CosBusOrder() { }
        // Create Or Update Order
        public async Task<CosApiResponse> CreateUpdateOrder(OrderRequest request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    var Order = request.Order;
                    if (string.IsNullOrEmpty(Order.Id)) /* insert */
                    {
                        Order.Id = Guid.NewGuid().ToString();
                        var orderDB = new Order()
                        {
                            Id = Order.Id,
                            CustomerId = Order.CustomerId,
                            ReceiptNo = Order.ReceiptNo,
                            OrderNo = Order.OrderNo,
                            TotalBill = Order.TotalBill,
                            Discount = Order.Discount,
                        };
                        _db.Orders.Add(orderDB);
                    }
                    else /* update */
                    {
                        var orderDB = _db.Orders.Where(o => o.Id == Order.Id && o.Status == (byte)Constants.EStatus.Actived).FirstOrDefault();
                        orderDB.CustomerId = Order.CustomerId;
                        orderDB.ReceiptNo = Order.ReceiptNo;
                        orderDB.OrderNo = Order.OrderNo;
                        orderDB.TotalBill = Order.TotalBill;
                        orderDB.Discount = Order.Discount;
                    }

                    /* save data */
                    if (_db.SaveChanges() > 0)
                        response.Success = true;
                    else
                        response.Message = "Unable to add new or update Order";
                    NSLog.Logger.Info("Response Create Update Order", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Create Update Order", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Delete Order
        public async Task<CosApiResponse> DeleteOrder(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    /* delete */
                    var OrderDB = _db.Orders.Where(o => o.Id == request.ID && o.Status == (byte)Constants.EStatus.Actived).FirstOrDefault();
                    if (OrderDB != null)
                    {

                        OrderDB.Status = (byte)Constants.EStatus.Deleted;
                        /* Save change data */
                        if (_db.SaveChanges() > 0)
                            response.Success = true;
                        else
                            response.Message = "Unable to delete Order";
                    }
                    else
                        response.Message = "Unable to find Order";
                    NSLog.Logger.Info("Response Delete Order", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Delete Order", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Get Detail Order
        public async Task<CosApiResponse> GetDetailOrder(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    GetDetailOrderResponse result = new GetDetailOrderResponse();

                    /* get order */
                    var OrderDB = _db.Orders.Where(o => o.Id == request.ID && o.Status == (byte)Constants.EStatus.Actived).FirstOrDefault();
                    if (OrderDB != null)
                    {
                        var responseOrder = new OrderDTO()
                        {
                            Id = OrderDB.Id,
                            CustomerId = OrderDB.CustomerId,
                            ReceiptNo = OrderDB.ReceiptNo,
                            OrderNo = OrderDB.OrderNo,
                            TotalBill = OrderDB.TotalBill,
                            Discount = OrderDB.Discount,
                        };
                        result.Order = responseOrder;
                        response.Data = result;
                    }
                    else
                        response.Message = "Unable to find Order";

                    NSLog.Logger.Info("Response Get Detail Order", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Get Detail Order", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Get List Order
        public async Task<CosApiResponse> GetListOrder(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    GetListOrderResponse result = new GetListOrderResponse();

                    /* get oder */
                    var query = _db.Orders.Where(o =>  o.Status == (byte)Constants.EStatus.Actived);

                    result.ListOrder = query.Select(o => new OrderDTO()
                    {
                        Id = o.Id,
                        CustomerId = o.CustomerId,
                        OrderNo = o.OrderNo,
                        ReceiptNo = o.ReceiptNo,
                        TotalBill = o.TotalBill,
                        Discount = o.Discount,
                    }).ToList();

                    /* response data  */
                    response.Data = result;

                    NSLog.Logger.Info("Response Get List Order", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Get List Order", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
    }
}
