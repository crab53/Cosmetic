using Cosmetic.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetic.DataModel.Model;
using Cosmetic.Bussiness.DTO;
using Cosmetic.Core.Request;
using Cosmetic.Bussiness.Requests;
using Cosmetic.Core.Common;
using Cosmetic.Bussiness.Responses;

namespace Cosmetic.Bussiness.Bussiness
{
    public class CosBusProduct : CosBusBase
    {
        protected static CosBusProduct _instance;
        public static CosBusProduct Instance
        {
            get
            {
                _instance = _instance != null ? _instance : new CosBusProduct();
                return _instance;
            }
        }
        static CosBusProduct() { }

        // Create Update Product
        public async Task<CosApiResponse> CreateUpdateProduct(CreateUpdateProductRequest request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    var pro = request.Pro;
                    if (string.IsNullOrEmpty(pro.ID)) /* insert */
                    {
                        pro.ID = Guid.NewGuid().ToString();
                        var proDB = new Product()
                        {
                            Id = pro.ID,
                            Name = pro.Name,
                            CategoryId = pro.CateID,
                            Price = (decimal)pro.Price,
                        };
                        _db.Products.Add(proDB);
                    }
                    else /* update */
                    {
                        var proDB = _db.Products.Where(o => o.Id == pro.ID).FirstOrDefault();
                        proDB.Price = (decimal)pro.Price;
                        proDB.Name = pro.Name;
                        proDB.CategoryId = pro.CateID;
                    }

                    /* save data */
                    if (_db.SaveChanges() > 0)
                        response.Success = true;
                    else
                        response.Message = "Unable to add new or update product.";
                    NSLog.Logger.Info("ResponseCreateUpdateProduct", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("ErrorCreateUpdateProduct", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }

        public async Task<CosApiResponse> DeleteProduct(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    /* delete */
                    var proDB = _db.Products.Where(o => o.Id == request.ID /*&& o.Status == Constants.Estatus.Active*/ ).FirstOrDefault();
                    if (proDB != null)
                    {
                        //proDB.Status = Constants.EStatus.Deleted;

                        /* Save change data */
                        if (_db.SaveChanges() > 0)
                            response.Success = true;
                        else
                            response.Message = "Unable to delete product.";
                    }
                    else
                        response.Message = "Unable to find product.";
                    NSLog.Logger.Info("ResponseDeleteProduct", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("ErrorDeleteProduct", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }

        public async Task<CosApiResponse> GetIDProduct(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    GetIDProductResponse result = new GetIDProductResponse();
                    
                    /* get product */
                    var proDB = _db.Products.Where(o => o.Id == request.ID /*&& o.Status == Constants.Estatus.Active*/ ).FirstOrDefault();
                    if (proDB != null)
                    {
                        var responsePro = new ProductDTO()
                        {
                            ID = proDB.Id,
                            Name = proDB.Name,
                            Price = (float)proDB.Price,
                        };
                        result.Pro = responsePro;
                        response.Data = result;
                    }
                    else
                        response.Message = "Unable to find product";
                    
                    NSLog.Logger.Info("ResponseGetIDProduct", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("ErrorGetIDProduct", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        public async Task<CosApiResponse> GetListProduct(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    GetListProductResponse result = new GetListProductResponse();

                    /* get product */
                    var query = _db.Products.Where(o =>true/* o.Status == Constants.EStatus.Actived*/);

                    result.ListProd = query.Select(o => new ProductDTO()
                    {
                        ID = o.Id,
                        Name = o.Name,
                        Price = (float)o.Price,
                    }).ToList();

                    /* response data  */
                    response.Data = result;
                    
                    NSLog.Logger.Info("ResponseGetListProduct", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("ErrorGetListProduct", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
    }
}
