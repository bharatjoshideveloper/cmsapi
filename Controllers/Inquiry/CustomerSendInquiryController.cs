using Microsoft.AspNetCore.Mvc;
using Mvc_CmsWebapi.CommonLayer.Model.Inquiry;
using Mvc_CmsWebapi.ServiceLayer.Inquiry;

namespace Mvc_CmsWebapi.Controllers.Inquiry
{
    [ApiController]
    public class CustomerSendInquiryController : ControllerBase
    {
        public readonly ICustomerSendInquirySL _customerSendInquirySL;
        public CustomerSendInquiryController(ICustomerSendInquirySL customerSendInquirySL)
        {
            _customerSendInquirySL = customerSendInquirySL;
        }
        [HttpPost]
        [Route("api/customer/addInquiry")]
        public async Task<IActionResult> SendInquiry(Request<CustomerSendInquiryRequest> request)
        {
            var response = await _customerSendInquirySL.CustomerSendInquiry(request);

            return Ok(response);
        }
    }
}
