using Mvc_CmsWebapi.CommonLayer.Model;

namespace Mvc_CmsWebapi.RepositoryLayer
{
    public interface IAdminViewInquiryRL
    {
        public Task<ViewInquiry> AdminViewInquiry();

    }
}
