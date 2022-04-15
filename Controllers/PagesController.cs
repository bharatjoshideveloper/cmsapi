using Microsoft.AspNetCore.Mvc;
using Mvc_CmsWebapi.CommonLayer.Model.Inquiry;
using Mvc_CmsWebapi.ServiceLayer.Pages;

namespace Mvc_CmsWebapi.Controllers
{
    [ApiController]
    public class PagesController : ControllerBase
    {
        public readonly IPagesSL _pagesSL;
        public PagesController(IPagesSL pagesSL)
        {
            _pagesSL = pagesSL;
        }
        [HttpPost]
        [Route("api/pages/add")]
        public async Task<IActionResult> AddPages(PagesRequest request)
        {
            var response = await _pagesSL.CreatePage(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/pages/list")]
        public async Task<IActionResult> ListofPages()
        {
            var response = await _pagesSL.ListofPages();
            return Ok(response);
        }

        [HttpPost]
        [Route("api/pages/update")]
        public async Task<IActionResult> EditPage(ListOfPagesRequest request)
        {
            var response = await _pagesSL.EditPage(request);
            return Ok(response);
        }
        [HttpGet]
        [Route("api/pages/detail")]
        public async Task<IActionResult> DetailPage([FromQuery] DetailOfPagesRequest request)
        {
            var response = await _pagesSL.DetailPage(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("api/pages/delete")]
        public async Task<IActionResult> DeletePage([FromQuery]  DetailOfPagesRequest request)
        {
            var response = await _pagesSL.DeletePage(request);
            return Ok(response);
        }
    }
}
