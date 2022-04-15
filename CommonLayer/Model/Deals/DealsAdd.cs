namespace Mvc_CmsWebapi.CommonLayer.Model.Deals
{
    public class DealsAddRequest
    {
        public int portal_id { get; set; }
        public string deals_type { get; set; }
        public string title { get; set; }
        public string image_url { get; set; }
        public string price { get; set; }
        public string description { get; set; }
        public string overview { get; set; }
        public string inclusion { get; set; }
        public string exclusion { get; set; }
        public string terms_condition { get; set; }

    }
    public class DealsAddResponse
    {
        public bool Issuccess { get; set; }
        public string message { get; set; }

    }
    public class Request<T>
    {
        public T? request { get; set; }
    }

    public class Response<T>
    {
        public T? response { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
      //  public string? Warning { get; set; }
    }
    public class DeleteDealRequest
    {
        public int deals_id { get; set; }
    }
    public class DeleteDealsResponse : DealsAddResponse
    {
    }

    public class UpdateDealsRequest : DealsAddRequest
    {
        public int deals_id { get; set; }
    }
    public class UpdateDealsResponse : DealsAddResponse
    {

    }
    public class ListOfDeals : DealsAddResponse
    {

        public List<ListOfDealsResponse>? listOfDealsResponse { get; set; }

    }
    public class ListOfDealsResponse : DealsAddRequest
    {
        public int deals_id { get; set; }
    }

    public  class  DealsOfDetailRequest : DeleteDealRequest
    {
    }
    
    public class DealsOfDetailResponse : DealsAddRequest
    {

    }
}
