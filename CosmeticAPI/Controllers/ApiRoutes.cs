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
        //--------------------------------------------------------------------------------
        public const string Category_CreateUpdate = "api/v1/Category/CreateUpdate";
        public const string Category_Delete = "api/v1/Category/Delete";
        public const string Category_Get_ID = "api/v1/Category/Get/ID";
        public const string Category_Get_List = "api/v1/Category/Get/List";
        #endregion
    }
}