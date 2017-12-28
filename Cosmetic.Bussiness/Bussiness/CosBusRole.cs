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
    public class CosBusRole
    {
        protected static CosBusRole _instance;
        public static CosBusRole Instance
        {
            get
            {
                _instance = _instance != null ? _instance : new CosBusRole();
                return _instance;
            }
        }
        static CosBusRole() { }
        // Create Or Update role
        public async Task<CosApiResponse> CreateUpdateRole(RoleRequest request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    var role = request.Role;
                    if (string.IsNullOrEmpty(role.Id)) /* insert */
                    {
                        role.Id = Guid.NewGuid().ToString();
                        var roleDB = new Role()
                        {
                            Id = role.Id,
                            Name = role.Name,                            
                            RoleLevel = role.RoleLevel,                            
                            ModulesId = role.ModulesId,                            
                        };
                        _db.Roles.Add(roleDB);
                    }
                    else /* update */
                    {
                        var roleDB = _db.Roles.Where(o => o.Id == role.Id).FirstOrDefault();
                        roleDB.Name = role.Name;                        
                    }

                    /* save data */
                    if (_db.SaveChanges() > 0)
                        response.Success = true;
                    else
                        response.Message = "Unable to add new or update role";
                    NSLog.Logger.Info("Response Create Update role", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Create Update role", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Delete Role
        public async Task<CosApiResponse> DeleteRole(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    /* delete */
                    var RoleDB = _db.Roles.Where(o => o.Id == request.ID /*&& o.Status == Constants.Estatus.Active*/ ).FirstOrDefault();
                    if (RoleDB != null)
                    {                       

                        /* Save change data */
                        if (_db.SaveChanges() > 0)
                            response.Success = true;
                        else
                            response.Message = "Unable to delete role";
                    }
                    else
                        response.Message = "Unable to find role";
                    NSLog.Logger.Info("Response Delete role", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Delete role", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Get Detail Role
        public async Task<CosApiResponse> GetDetailRole(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    GetDetailRoleResponse result = new GetDetailRoleResponse();

                    /* get Role */
                    var RoleDB = _db.Roles.Where(o => o.Id == request.ID /*&& o.Status == Constants.Estatus.Active*/ ).FirstOrDefault();
                    if (RoleDB != null)
                    {
                        var responseRole = new RoleDTO()
                        {
                            Id = RoleDB.Id,
                            Name = RoleDB.Name,
                            RoleLevel= RoleDB.RoleLevel,                          
                            ModulesId = RoleDB.ModulesId,                            
                        };
                        result.Role = responseRole;
                        response.Data = result;
                    }
                    else
                        response.Message = "Unable to find role";

                    NSLog.Logger.Info("Response Get Detail role", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Get Detail role", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
        // Get List Role
        public async Task<CosApiResponse> GetListRole(RequestModelBase request)
        {
            var response = new CosApiResponse();
            try
            {
                using (var _db = new CosContext())
                {
                    GetListRoleResponse result = new GetListRoleResponse();

                    /* get Role */
                    var query = _db.Roles.Where(o => true/* o.Status == Constants.EStatus.Actived*/);

                    result.ListRole = query.Select(o => new RoleDTO()
                    {
                        Id = o.Id,
                        Name = o.Name,
                        ModulesId =o.ModulesId,
                        RoleLevel = o.RoleLevel,                        
                        
                    }).ToList();

                    /* response data  */
                    response.Data = result;

                    NSLog.Logger.Info("Response Get List role", response);
                }
            }
            catch (Exception ex) { NSLog.Logger.Error("Error Get List role", null, response, ex); }
            finally { /*_db.Refresh();*/ }
            return response;
        }
    }
}