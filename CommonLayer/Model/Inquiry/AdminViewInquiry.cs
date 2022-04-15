using Mvc_CmsWebapi.CommonLayer.Model.Inquiry;

namespace Mvc_CmsWebapi.CommonLayer.Model
{
    public class ViewInquiry
    {
        public bool Issuccess { get; set; }
        public string Message { get; set; }
        public List<AdminViewInquiryResponse> adminViewInquiryResponses { get; set; }
    }


    public class AdminViewInquiryResponse : CustomerSendInquiryRequest
    {
        public int inquiry_id { get; set; }
        


    }

}