using Mvc_CmsWebapi.CommonLayer.Model;

namespace Mvc_CmsWebapi.RepositoryLayer
{
    public interface IAdminRL
    {
        public Task<CreateRecordResponse> CreateRecord(Request<Admin> request);

        public Task<ReadRecordResponse> ReadRecord();

        public Task<UpdateAdminResponse> UpdateAdmin(UpdateAdminRequest request);

        public Task<DeleteAdminResponse> DeleteAdmin(DeleteAdminRequest request);

        public Task<AdminDetailResponse> AdminDetail(AdminDetailRequest request);
    }
}
