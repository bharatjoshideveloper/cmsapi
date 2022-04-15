using Microsoft.AspNetCore.Mvc;
using Mvc_CmsWebapi.CommonLayer.Model.Portals;
using Mvc_CmsWebapi.ServiceLayer.Portal;

namespace Mvc_CmsWebapi.Controllers
{
    public class PortalController:ControllerBase
    {
        public readonly IPortalSL _portalSL;
        public PortalController(IPortalSL portalSL)
        {
            _portalSL=portalSL;
        }
        [HttpPost]
        [Route("api/portal/add")]
        public async Task<IActionResult> AddPortal([FromBody] PortalRequest request)
        {
            var response=await _portalSL.AddPortal(request);
            return Ok(response);
        }
        [HttpPost]
        [Route("api/portal/update")]
        public async Task<IActionResult> UpdatePortal([FromBody] UpdateRequest request)
        {
            var response = await _portalSL.UpdatePortal(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/portal/list")]
        public async Task<IActionResult> Listofportal()
        {
            var response = await _portalSL.Listofportal();
            return Ok(response);
        }


        //[HttpGet]
        //[Route("api/portal/list")]
        //public async Task<IActionResult> Listofportal()
        //{
        //    var response=await _portalSL.Listofportal();
        //    return Ok(response);
        //}

        [HttpDelete]
        [Route("api/portal/delete")]
        public async Task<IActionResult> DeletePortal([FromQuery] DeletePortalRequest request)
        {
            var response = await _portalSL.DeletePortal(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/portal/detail")]
        public async Task<IActionResult> DetailPortal([FromQuery] DeletePortalRequest request)
        {
            var response = await _portalSL.DetailPortal(request);
            return Ok(response);
        }

    }
}
