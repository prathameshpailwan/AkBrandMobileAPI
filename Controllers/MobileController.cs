using AkBrandMobile.BAL;
using AkBrandMobile.Models;
using Microsoft.AspNetCore.Mvc;

namespace AkBrandMobile.Controllers
{
    [Route("api/MobileController")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly MobileTransaction mobile_Transaction;
        public MobileController(MobileTransaction mobileTransaction)
        {
            mobile_Transaction = mobileTransaction;
        }

        [HttpPost]
        [Route("GetMobile")]
        public IActionResult GetMobile()
        {
            var mobileData = mobile_Transaction.GetMobileData();
            if (mobileData != null)
            {
                // If mobileData is already a JsonResult, return it directly
                return mobileData;
            }
            else
            {
                // Handle the case where no data is returned
                return NotFound(new { message = "No mobile data found." });
            }
        }

        [HttpGet]
        [Route("GetAccesories")]
        public IActionResult GetAccesories()
        {
            var mobileData = mobile_Transaction.GetAccesories();
            if (mobileData != null)
            {
                // If mobileData is already a JsonResult, return it directly
                return mobileData;
            }
            else
            {
                // Handle the case where no data is returned
                return NotFound(new { message = "No mobile data found." });
            }
        }

        [HttpPost]
        [Route("InsertUpdate_Accesories")]
        public IActionResult InsertUpdate_Accesories([FromBody] AccessoryModel accessoryModel)
        {
            var mobileData = mobile_Transaction.InsertUpdate_Accesories(accessoryModel);
            if (mobileData != null)
            {
                // If mobileData is already a JsonResult, return it directly
                return mobileData;
            }
            else
            {
                // Handle the case where no data is returned
                return NotFound(new { message = "No mobile data found." });
            }
        }

        [HttpPost]
        [Route("AddTypeCompanyColour")]
        public IActionResult AddTypeCompanyColour([FromBody] TypeCompanyColourModel typeCompanyColour)
        {
            var mobileData = mobile_Transaction.AddTypeCompanyColour(typeCompanyColour);
            if (mobileData != null)
            {
                return mobileData;
            }
            else
            {
                return NotFound(new { message = "No mobile data found." });
            }
        }

        [HttpGet]
        [Route("GetMobileMasterData")]
        public IActionResult GetMobileMasterData()
        {
            var mobileData = mobile_Transaction.GetMobileMasterData();
            if (mobileData != null)
            {
                // If mobileData is already a JsonResult, return it directly
                return mobileData;
            }
            else
            {
                // Handle the case where no data is returned
                return NotFound(new { message = "No mobile data found." });
            }
        }
        [HttpPost]
        [Route("MobileModelTransaction")]
        public IActionResult MobileModelTransaction([FromBody] ModelTransaction modelTransaction)
        {
            var mobileData = mobile_Transaction.MobileModelTransaction(modelTransaction);
            if (mobileData != null)
            {
                return mobileData;
            }
            else
            {
                return NotFound(new { message = "No mobile data found." });
            }
        }

    }
}
