using Microsoft.AspNetCore.Mvc;
using Mvc_CmsWebapi.CommonLayer.Model.Contact;
using Mvc_CmsWebapi.ServiceLayer.Contact;

namespace Mvc_CmsWebapi.Controllers
{
    public class ContactController :ControllerBase
    {
        public readonly IContactSL _contactSL;
        public ContactController(IContactSL contactSL)
        {
            _contactSL = contactSL;
        }
        [HttpPost]
        [Route("api/contact/add")]
        public async Task<IActionResult> Addcontact([FromBody] Request<ContactRequest> request)
        {
            var response = await _contactSL.Addcontact(request);
            return Ok(response);
        }
        [HttpPost]
        [Route("api/contact/update")]
        public async Task<IActionResult> Updatecontact([FromQuery] Request<ContactUpdateRequest> request)
        {
            var response = await _contactSL.Updatecontact(request);
            return Ok(response);
        }
    }
}
