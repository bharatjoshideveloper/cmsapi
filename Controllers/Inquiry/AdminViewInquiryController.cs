using Microsoft.AspNetCore.Mvc;
using Mvc_CmsWebapi.CommonLayer.Model;
using Mvc_CmsWebapi.ServiceLayer.Inquiry;

namespace Mvc_CmsWebapi.Controllers.Inquiry
{
    [ApiController]

    public class AdminViewInquiryController : ControllerBase
    {
        public readonly IAdminViewInquirySL _adminViewInquirySL;

        public AdminViewInquiryController(IAdminViewInquirySL adminViewInquirySL)
        {
            _adminViewInquirySL = adminViewInquirySL;
        }

        [HttpGet]
        [Route("api/admin/ViewInquiry")]
        public async Task<IActionResult> GetInquiryDetails()
        {

            ViewInquiry response = null;
            try
            {
                response = await _adminViewInquirySL.AdminViewInquiry();
            }
            catch (Exception ex)
            {
                response.Issuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

    }

}