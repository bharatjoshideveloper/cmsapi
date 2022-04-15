using Microsoft.AspNetCore.Mvc;
using Mvc_CmsWebapi.CommonLayer.Model.Deals;

namespace Mvc_CmsWebapi.ServiceLayer.Deals
{
    public interface IDealsAddSL
    {
        public Task<Response<string>> CreateDeals(Request<DealsAddRequest> request);

        public Task<ListOfDeals> ListDeals();

        public Task<UpdateDealsResponse> UpdateDeals(UpdateDealsRequest request);

        public Task<DeleteDealsResponse> DeleteDeals(DeleteDealRequest request);

        public Task<Response<DealsOfDetailResponse>> DealsDetail(Request<DealsOfDetailRequest> request);
    }
}
