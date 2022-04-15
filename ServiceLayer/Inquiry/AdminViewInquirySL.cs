
using Mvc_CmsWebapi.CommonLayer.Model;
using Mvc_CmsWebapi.RepositoryLayer;

namespace Mvc_CmsWebapi.ServiceLayer.Inquiry
{
    public class AdminViewInquirySL : IAdminViewInquirySL
    {
        public readonly IAdminViewInquiryRL _adminViewInquiryRL;

        public AdminViewInquirySL(IAdminViewInquiryRL adminViewInquiryRL)
        {
            _adminViewInquiryRL = adminViewInquiryRL;
        }

        public async Task<ViewInquiry> AdminViewInquiry()
        {
            return await _adminViewInquiryRL.AdminViewInquiry();
        }

       
    }
}