using Mvc_CmsWebapi.CommonLayer.Model;

namespace Mvc_CmsWebapi.ServiceLayer.Inquiry
{
    public interface IAdminViewInquirySL
    {
        public Task<ViewInquiry> AdminViewInquiry(); 
    }
}
