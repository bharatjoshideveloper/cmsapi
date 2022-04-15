using Mvc_CmsWebapi.CommonLayer.Model.Inquiry;

namespace Mvc_CmsWebapi.RepositoryLayer.Inquiry
{
    public interface ICustomerSendInquiryRL
    {
        public Task<CustomerSendInquiryResponse> CustomerSendInquiry(Request<CustomerSendInquiryRequest> request);


    }
}
