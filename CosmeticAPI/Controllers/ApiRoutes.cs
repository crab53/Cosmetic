using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CosmeticAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiRoutes
    {
        #region -- NuPOS --
        /*------------------------------------------------------------------------------------------------------*\
        * Product Route
        \*------------------------------------------------------------------------------------------------------*/
        public const string Product_CreateUpdate = "api/v1/Product/CreateUpdate";
        public const string Product_Delete = "api/v1/Product/Delete";
        public const string Product_Get_ID = "api/v1/Product/Get/ID";
        public const string Product_Get_List = "api/v1/Product/Get/List";
        //Category --------------------------------------------------------------------------------
        public const string Category_CreateUpdate = "api/v1/Category/CreateUpdate";
        public const string Category_Delete = "api/v1/Category/Delete";
        public const string Category_Get_ID = "api/v1/Category/Get/ID";
        public const string Category_Get_List = "api/v1/Category/Get/List";
        //Category --------------------------------------------------------------------------------
        public const string User_CreateUpdate = "api/v1/User/CreateUpdate";
        public const string User_Delete = "api/v1/User/Delete";
        public const string User_Get_ID = "api/v1/User/Get/ID";
        public const string User_Get_List = "api/v1/User/Get/List";
        //Category --------------------------------------------------------------------------------
        public const string Order_CreateUpdate = "api/v1/Order/CreateUpdate";
        public const string Order_Delete = "api/v1/Order/Delete";
        public const string Order_Get_ID = "api/v1/Order/Get/ID";
        public const string Order_Get_List = "api/v1/Order/Get/List";
        //Category --------------------------------------------------------------------------------
        public const string Customer_CreateUpdate = "api/v1/Customer/CreateUpdate";
        public const string Customer_Delete = "api/v1/Customer/Delete";
        public const string Customer_Get_ID = "api/v1/Customer/Get/ID";
        public const string Customer_Get_List = "api/v1/Customer/Get/List";
        //Category --------------------------------------------------------------------------------
        public const string Role_CreateUpdate = "api/v1/Role/CreateUpdate";
        public const string Role_Delete = "api/v1/Role/Delete";
        public const string Role_Get_ID = "api/v1/Role/Get/ID";
        public const string Role_Get_List = "api/v1/Role/Get/List";
        //Category --------------------------------------------------------------------------------
        public const string Price_CreateUpdate = "api/v1/Price/CreateUpdate";
        public const string Price_Delete = "api/v1/Price/Delete";
        public const string Price_Get_ID = "api/v1/Price/Get/ID";
        public const string Price_Get_List = "api/v1/Price/Get/List";
        #endregion
    }
}