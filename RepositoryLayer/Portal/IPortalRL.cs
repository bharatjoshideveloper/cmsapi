using Mvc_CmsWebapi.CommonLayer.Model.Portals;

namespace Mvc_CmsWebapi.RepositoryLayer.Portal
{
    public interface IPortalRL
    {
        public Task<PortalResponse> AddPortal(PortalRequest request);

        public Task<PortalResponse> UpdatePortal(UpdateRequest request);
        public Task<PagesList> Listofportal();

        public Task<PortalResponse> DeletePortal(DeletePortalRequest request);

        public Task<PortalRequest> DetailPortal(DeletePortalRequest request);
    }
}
