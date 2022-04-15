using Mvc_CmsWebapi.CommonLayer.Model;
using Mvc_CmsWebapi.RepositoryLayer;

namespace Mvc_CmsWebapi.ServiceLayer
{
    public class AdminSL : IAdminSL
    {
        public readonly IAdminRL _adminRL;

        public AdminSL(IAdminRL adminRL)
        {
            _adminRL = adminRL;
        }

        public async Task<Response<string>> CreateRecord(Request<Admin> request)
        {
            // Validate request parameters


            var slResponse = new Response<string>();

            var response = await _adminRL.CreateRecord(request);
            if (response.IsSuccess)
            {
                slResponse.response = "Success";
                slResponse.Success = true;
            }
            else
            {
                slResponse.response = "Error";
                slResponse.Success = false;
                slResponse.Message = response.Message;
            }

            return slResponse;
        }

        public async Task<DeleteAdminResponse> DeleteAdmin(DeleteAdminRequest request)
        {
            return await _adminRL.DeleteAdmin(request);
        }

        public async Task<AdminDetailResponse> AdminDetail(AdminDetailRequest request)
        {
            return await _adminRL.AdminDetail(request);
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            return await _adminRL.ReadRecord();
        }

        public async Task<UpdateAdminResponse> UpdateAdmin(UpdateAdminRequest request)
        {
            return await _adminRL.UpdateAdmin(request);
        }
    }
}
