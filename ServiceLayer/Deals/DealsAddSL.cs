using Microsoft.AspNetCore.Mvc;
using Mvc_CmsWebapi.CommonLayer.Model.Deals;
using Mvc_CmsWebapi.RepositoryLayer.Deals;

namespace Mvc_CmsWebapi.ServiceLayer.Deals
{
    public class DealsAddSL : IDealsAddSL
    {
        public readonly IDealsAddRL _dealsAddRL;
        public  DealsAddSL (IDealsAddRL dealsAddRL)
        {
            _dealsAddRL = dealsAddRL;
        }

       
       
public async Task<Response<string>> CreateDeals(Request<DealsAddRequest> request)
        {
            var slResponse = new Response<string>();

            var response = await _dealsAddRL.CreateDeals(request);
            if (response.Issuccess)
            {
                slResponse.response = "Success";
                slResponse.Success = true;
            }
            else
            {
                slResponse.response = "Error";
                slResponse.Success = false;
                slResponse.Message = response.message;
            }

            return slResponse;

        }

        public async Task<DeleteDealsResponse> DeleteDeals(DeleteDealRequest request)
        {
            return await _dealsAddRL.DeleteDeals(request);
        }

        public async Task<ListOfDeals> ListDeals()
        {
            return await _dealsAddRL.ListDeals();
        }

        public async Task<UpdateDealsResponse> UpdateDeals(UpdateDealsRequest request)
        {
            return await _dealsAddRL.UpdateDeals(request);
        }

        public async Task<Response<DealsOfDetailResponse>> DealsDetail(Request<DealsOfDetailRequest> request)
        {
            return await _dealsAddRL.DealsDetail(request);
        }
    }
}
