using Cosmetic.Bussiness.DTO;
using Cosmetic.Bussiness.Requests;
using Cosmetic.Bussiness.Responses;
using Cosmetic.Core.Request;
using Cosmetic.Core.Response;
using Cosmetic.DataModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using Cosmetic.DataModel.Entities;

namespace Cosmetic.Bussiness.Bussiness
{
    public class CosBusPrice
    {
        protected static CosBusPrice _instance;
        public static CosBusPrice Instance
        {
            get
            {
                _instance = _instance != null ? _instance : new CosBusPrice();
                return _instance;
            }
        }
        static CosBusPrice() { }
        // Create Or Update Price
        public async Task<CosApiResponse> CreateUpdatePrice(PriceRequest request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosmeticsContext())
                {
                    var Price = request.Price;
                    if (string.IsNullOrEmpty(Price.Id)) /* insert */
                    {
                        Price.Id = Guid.NewGuid().ToString();
                        var priceDB = new Price()
                        {
                            Id = Price.Id,
                            Prices = Price.Price,
                            ToDate = Price.ToDate,
                            FromDate = Price.FromDate,
                            ProductId = Price.ProductId

                        };
                        _db.Prices.Add(priceDB);
                    }
                    else /* update */
                    {
                        var PriceDB = _db.Prices.Where(o => o.Id == Price.Id).FirstOrDefault();
                        PriceDB.Prices = Price.Price;
                        PriceDB.ToDate = Price.ToDate;
                        PriceDB.FromDate = Price.FromDate;
                        PriceDB.ProductId = Price.ProductId;
                    }

                    /* save data */
                    if (_db.SaveChanges() > 0)
                        response.Success = true;
                    else
                        response.Message = "Unable to add new or update Price";
                    NSLog.Logger.Info("Response Create Update UsPriceer", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Create Update Price", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Delete Price
        public async Task<CosApiResponse> DeletePrice(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosmeticsContext())
                {
                    /* delete */
                    var PriceDB = _db.Prices.Where(o => o.Id == request.ID /*&& o.Status == Constants.Estatus.Active*/ ).FirstOrDefault();
                    if (PriceDB != null)
                    {                        

                        /* Save change data */
                        if (_db.SaveChanges() > 0)
                            response.Success = true;
                        else
                            response.Message = "Unable to delete Price";
                    }
                    else
                        response.Message = "Unable to find Price";
                    NSLog.Logger.Info("Response Delete Price", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Delete Price", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Get Detail Price
        public async Task<CosApiResponse> GetDetailPrice(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosmeticsContext())
                {
                    GetDetailPriceResponse result = new GetDetailPriceResponse();

                    /* get Price */
                    var PriceDB = _db.Prices.Where(o => o.Id == request.ID /*&& o.Status == Constants.Estatus.Active*/ ).FirstOrDefault();
                    if (PriceDB != null)
                    {
                        var responsePrice = new PriceDTO()
                        {
                            Id = PriceDB.Id,                            
                            ToDate = PriceDB.ToDate,
                            FromDate = PriceDB.FromDate,
                            ProductId = PriceDB.ProductId,
                            Price = PriceDB.Prices,                            
                        };
                        result.Price = responsePrice;
                        response.Data = result;
                    }
                    else
                        response.Message = "Unable to find Price";

                    NSLog.Logger.Info("Response Get Detail Price", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Get Detail Price", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Get List Price
        public async Task<CosApiResponse> GetListPrice(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosmeticsContext())
                {
                    GetListPriceResponse result = new GetListPriceResponse();

                    /* get Price */
                    var query = _db.Prices.Where(o => true/* o.Status == Constants.EStatus.Actived*/);

                    result.ListPrice = query.Select(o => new PriceDTO()
                    {
                        Id = o.Id,
                        ToDate = o.ToDate,
                        FromDate = o.FromDate,
                        ProductId = o.ProductId,
                        Price = o.Prices,
                    }).ToList();

                    /* response data  */
                    response.Data = result;

                    NSLog.Logger.Info("Response Get List Price", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Get List Price", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
    }
}
