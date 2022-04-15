using Mvc_CmsWebapi.CommonLayer.Model.Inquiry;

namespace Mvc_CmsWebapi.ServiceLayer.Inquiry
{
    public interface ICustomerSendInquirySL
    {
        public Task<Response<string>> CustomerSendInquiry(Request<CustomerSendInquiryRequest> request);


    }
}
