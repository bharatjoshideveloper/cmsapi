using Mvc_CmsWebapi.CommonLayer.Model.Portals;
using Mvc_CmsWebapi.RepositoryLayer.Portal;

namespace Mvc_CmsWebapi.ServiceLayer.Portal
{
    public class PortalSL :IPortalSL
    {
        public readonly IPortalRL _portalRL;

        public PortalSL(IPortalRL portalRL)
        {
            _portalRL = portalRL;
        }

        public async Task<PortalResponse> AddPortal(PortalRequest request)
        {
            return await _portalRL.AddPortal(request);
        }

        public async Task<PortalResponse> UpdatePortal(UpdateRequest request)
        {
            return await _portalRL.UpdatePortal(request);
        }


        public async Task<PagesList> Listofportal()
        {
            return await _portalRL.Listofportal();
        }
       

        public async Task<PortalResponse> DeletePortal(DeletePortalRequest request)
        {
            return await _portalRL.DeletePortal(request);
        }

        public async Task<PortalRequest> DetailPortal(DeletePortalRequest request)
        {
            return await _portalRL.DetailPortal(request);
        }

       
    }
}
