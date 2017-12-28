﻿using Cosmetic.Bussiness.DTO;
using Cosmetic.Bussiness.Requests;
using Cosmetic.Bussiness.Responses;
using Cosmetic.Core.Request;
using Cosmetic.Core.Response;
using Cosmetic.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.Bussiness.Bussiness
{
   public class CosBusCategory: CosBusBase
    {
        protected static CosBusCategory _instance;
        public static CosBusCategory Instance
        {
            get
            {
                _instance = _instance != null ? _instance : new CosBusCategory();
                return _instance;
            }
        }
        static CosBusCategory()
        { }
        // Create Or Update Category
        public async Task<CosApiResponse> CreateUpdateCategory(CategoryRequests requests)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    var Cate = requests.Category;
                    if(string.IsNullOrEmpty(Cate.Id))
                    {
                        Cate.Id = Guid.NewGuid().ToString();
                        var cateDB = new Category()
                        {
                            Id = Cate.Id,
                            Name = Cate.Name,
                            ParentId = Cate.ParentId,
                            Status = Cate.Status,
                        };
                        _db.Categories.Add(cateDB);
                    }
                    else
                    {
                        var cateDB = _db.Categories.Where(x => x.Id == Cate.Id).FirstOrDefault();
                        cateDB.Name = Cate.Name;
                        cateDB.ParentId = Cate.ParentId;
                        cateDB.Status = Cate.Status;                      
                    }
                    if (_db.SaveChanges() > 0)
                        response.Success = true;
                    else
                    {
                        response.Message = "Unable to add new or update category";
                        NSLog.Logger.Info("Response Create or Update Category");
                    }
                }
            }
            catch(Exception ex)
            {
                NSLog.Logger.Error("Error Create Or Update Category", null, response, ex);
            }
            finally { }
            return response;
        }
        // Delete Category
        public async Task<CosApiResponse> DeleteCatgory(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    /* delete */
                    var cateDB = _db.Categories.Where(x => x.Id == request.ID).FirstOrDefault();
                    if(cateDB != null)
                    {
                        if (_db.SaveChanges() > 0)
                            response.Success = true;
                        else
                            response.Message = "Unable to delete category";
                    }
                    else
                    {
                        response.Message = " Unable to find category";
                        NSLog.Logger.Info("Response Delete Category");
                    }
                }
            }
            catch(Exception ex) { NSLog.Logger.Error("Error Delete Category", null, response, ex); }
            finally { }
            return response;
        }
        // Get List Category
        public async Task<CosApiResponse> GetListCategory(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    GetListCategoryResponse result = new GetListCategoryResponse();
                    var query = _db.Categories.Where(x => true);
                    result.ListCate = query.Select(x => new CategoryDTO()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ParentId =x.ParentId,
                        Status = x.Status
                    }).ToList();
                    response.Data = result;
                    NSLog.Logger.Info("Response Get List Category", response);
                }
            }
            catch(Exception ex) { NSLog.Logger.Error("Error Get List Category", null, response, ex); }
            finally { }
            return response;
        }
        // Get Detail Category
        public async Task<CosApiResponse> GetDetailCategory(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    GetIDCategoryResponse result = new GetIDCategoryResponse();
                    var cateDB = _db.Categories.Where(x => x.Id == request.ID).FirstOrDefault();
                    if(cateDB != null)
                    {
                        var responseCate = new CategoryDTO()
                        {
                            Id = cateDB.Id,
                            Name = cateDB.Name,
                            ParentId = cateDB.ParentId,
                            Status = cateDB.Status
                        };                        
                    }
                    else
                    {
                        response.Message = "Unable to find category";
                        NSLog.Logger.Info("Response Get Detail Category", response);
                    }
                }
                
            }
            catch(Exception ex) { NSLog.Logger.Error("Error Get Detail Category", null, response, ex); }
            finally { }
            return response;
        }
    }
}