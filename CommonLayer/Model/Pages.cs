namespace Mvc_CmsWebapi.CommonLayer.Model.Inquiry
{
    public class PagesRequest
    {
        public int portal_id { get; set; }
        public string page_name { get;set; }
        public string page_title { get;set; }
        public string content { get;set; }
    }
    public class PagesResponse
    {
        public bool Success { get;set; }
        public string message { get;set; }

    }
    public class PagesList:PagesResponse
    {
            public List<ListOfPagesRequest>? listOfPagesRequests { get; set; }

    }
    public class ListOfPagesRequest : PagesRequest
    {
            public int page_id { get; set; }
    }
    public class DetailOfPagesRequest
    {
        public int page_id { get; set; }
    }
    public class DetailOfPagesResponse:PagesRequest
    {
    }
}
