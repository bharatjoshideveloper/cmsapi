using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_CmsWebapi.CommonLayer.Model.Deals;
using Mvc_CmsWebapi.ServiceLayer.Deals;

namespace Mvc_CmsWebapi.Controllers
{
    [ApiController]

    public class DealsController : ControllerBase
    {
        public readonly IDealsAddSL _dealsAddSL;
        public DealsController(IDealsAddSL dealsAddSL)
        {
            _dealsAddSL = dealsAddSL;
        }


        [HttpPost]
        [Route("api/admin/deals/add")]
        public async Task<IActionResult> AddDeals(Request<DealsAddRequest> request)
        {
            var response = await _dealsAddSL.CreateDeals(request);

            return Ok(response);
        }


        [HttpGet]
        [Route("api/admin/deals/list")]
        public async Task<IActionResult> GetDealsList()
        {

            ListOfDeals response = null;
            try
            {
                response = await _dealsAddSL.ListDeals();
            }
            catch (Exception ex)
            {
                response.Issuccess= false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("api/admin/deals/update")]
        public async Task<IActionResult>UpdateDeals(UpdateDealsRequest request)
        {
            UpdateDealsResponse response = null;
            try
            {
                response = await _dealsAddSL.UpdateDeals(request);

            }
            catch(Exception ex)
            {

            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("api/admin/deals/delete")]
        public async Task<IActionResult> DeleteDeals([FromQuery] DeleteDealRequest request)
        {
            DealsAddResponse response = null;
            try
            {
                response = await _dealsAddSL.DeleteDeals(request);
            }
            catch(Exception ex)
            {
                response.message = ex.Message;
                response.Issuccess = false;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("api/customer/deals/detail")]
        public async Task<IActionResult> DealsDetail([FromQuery] Request<DealsOfDetailRequest> request)
        {
            Response<DealsOfDetailResponse> response = new Response<DealsOfDetailResponse>();
            try
            {
                response = await _dealsAddSL.DealsDetail(request);
            }
            catch(Exception ex)
            {
               response.Message=ex.Message;
                response.Success=false;
            }
            return Ok(response);
        }

    }
}
