using Mvc_CmsWebapi.CommonLayer.Model.Inquiry;
using Mvc_CmsWebapi.RepositoryLayer.Inquiry;

namespace Mvc_CmsWebapi.ServiceLayer.Inquiry
{
    public class CustomerSendInquirySL : ICustomerSendInquirySL
    {
        public readonly ICustomerSendInquiryRL _customerSendInquiryRL;

        public CustomerSendInquirySL(ICustomerSendInquiryRL customerSendInquiryRL)
        {
            _customerSendInquiryRL = customerSendInquiryRL;
        }




        public async Task<Response<string>> CustomerSendInquiry(Request<CustomerSendInquiryRequest> request)
        {

            var slResponse = new Response<string>();

            var response = await _customerSendInquiryRL.CustomerSendInquiry(request);
            if (response.Issuccess)
            {
                slResponse.response = "Success";
                slResponse.Success = true;
            }
            else
            {
                slResponse.response = "Error";
                slResponse.Success = false;
                slResponse.Message = response.Message;
            }

            return slResponse;

        }
    }
}
