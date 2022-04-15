using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_CmsWebapi.CommonLayer.Model;
using Mvc_CmsWebapi.ServiceLayer;

namespace Mvc_CmsWebapi.Controllers
{
    
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly IAdminSL _adminSL;

        public AdminController(IAdminSL adminSL)
        {
            _adminSL = adminSL;
        }

        [HttpPost]
        [Route("api/admin/add")]
        public async Task<IActionResult> AddAdmin(Request<Admin> request)
        {
            var response = await _adminSL.CreateRecord(request);

            return Ok(response);
        }


        [HttpGet]
        [Route("api/admin/list")]
        public async Task<IActionResult> GetAdminDetails()
        {

            ReadRecordResponse response = null;
            try
            {
                response = await _adminSL.ReadRecord();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

/*
        [httpget]
        [route("api/admin/list")]
        public async task<iactionresult> getadminlist()
        {
            var slresponse = new response<list<admin>>();

            var response = new list<admin>();

            response.add(new admin()
            {
                first_nm = "aaa",
                last_nm = "bbb"
            });

            response.add(new admin()
            {
                first_nm = "ccc",
                last_nm = "ddd"
            });

            slresponse.response = response;
            slresponse.success = true;

            return ok(slresponse);
        }
*/
        [HttpPut]
        [Route("api/admin/update")]
        public async Task<IActionResult> UpdateAdmin(UpdateAdminRequest request)
        {
            UpdateAdminResponse response = null;
            try
            {
                response = await _adminSL.UpdateAdmin(request);

                }
                catch (Exception ex)
                {

                }
                return Ok(response);
            }

        [HttpPost]
        [Route("api/admin/detail")]
        public async Task<IActionResult> AdminDetail(AdminDetailRequest request)
        {
            AdminDetailResponse response = null;
            try
            {
                response = await _adminSL.AdminDetail(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("api/admin/delete")]
        public async Task<IActionResult> DeleteAdmin(DeleteAdminRequest request)
        {
            DeleteAdminResponse response = null;
            try
            {
                response = await _adminSL.DeleteAdmin(request);
            }
            catch (Exception ex)
            {
                response.success = false;
                response.message = ex.Message;
            }
            return Ok(response);
        }

    }
}