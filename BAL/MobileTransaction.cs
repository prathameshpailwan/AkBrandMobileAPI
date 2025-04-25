using AkBrandMobile.Common;
using AkBrandMobile.DAL;
using AkBrandMobile.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AkBrandMobile.BAL
{
    public class MobileTransaction
    {

        private readonly MobileDbConnection _mobileDbConnection;
        private readonly ConversionsClass _conversions;


        public MobileTransaction(MobileDbConnection mobileDbConnection, ConversionsClass conversions)
        {
            _mobileDbConnection = mobileDbConnection;
            _conversions = conversions;
        }
        public JsonResult GetMobileData()
        {

            var response = _mobileDbConnection.ExecuteStoredProcedure("GetMobileData", null, true);
            if (response != null)
            {
                return new JsonResult(response);

            }
            else
            {
                return new JsonResult("No Data Found");
            }
        }

        public JsonResult GetAccesories()
        {
            var response = _mobileDbConnection.ExecuteStoredProcedure("GetAccessories", null, true);
            if (response != null)
            {
                return new JsonResult(response);
            }
            else
            {
                return new JsonResult("No Data Found");
            }
        }

        public JsonResult InsertUpdate_Accesories(AccessoryModel accessoryModel)
        {
            var parameters = _conversions.CreateParametersFromModel(accessoryModel);
            DataTable detailTable = null;
            var response = _mobileDbConnection.ExecuteStoredProcedure("Accessories_Insert_Update", parameters, false);
            if (response != null)
            {
                return new JsonResult(response);

            }
            else
            {
                return new JsonResult("No Data Found");
            }
        }

        public JsonResult AddTypeCompanyColour(TypeCompanyColourModel typeCompanyColour)
        {
            var parameters = _conversions.CreateParametersFromModel(typeCompanyColour);
            DataTable detailTable = null;
            var response = _mobileDbConnection.ExecuteStoredProcedure("InsertMobileType_Company_Colour", parameters, false);
            if (response != null)
            {
                return new JsonResult(response);

            }
            else
            {
                return new JsonResult("No Data Found");
            }
        }

        public JsonResult MobileModelTransaction(ModelTransaction modelTransaction)
        {
            var parameters = _conversions.CreateParametersFromModel(modelTransaction);
            DataTable detailTable = null;
            var response = _mobileDbConnection.ExecuteStoredProcedure("MobileModelTransaction", parameters, false);
            if (response != null)
            {
                return new JsonResult(response);

            }
            else
            {
                return new JsonResult("No Data Found");
            }
        }
        public JsonResult GetMobileMasterData()
        {
            var response = _mobileDbConnection.ExecuteStoredProcedure("Get_MobileType_Company_Colour", null, true);
            if (response != null)
            {
                return new JsonResult(response);
            }
            else
            {
                return new JsonResult("No Data Found");
            }
        }

    }
}
