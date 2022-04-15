namespace Mvc_CmsWebapi.CommonLayer.Model.Portals
{
    public class PortalRequest
    {
        public string site_url { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string contactno { get; set; }
        public string company_name { get; set; }
        public string logo { get; set; }
        public string currency { get; set; }
        public string languages { get; set; }
        public string isactive { get; set; }

    }
    public class PortalResponse
    {
        public bool success { get; set; }
        public string message { get; set; }

    }
    public class Request<T>
    {
        public T? request { get; set; }
    }
    public class Response<T>
    {
        public T? response { get; set;}
        public string success { get; set; }
        public bool message { get; set; }
    }
    public class UpdateRequest:PortalRequest
    {
        public int portal_id { get; set; }
    }
    
    public class PagesList : PortalResponse
    {
        public List<ListOfPagesRequest>? listOfPagesRequests { get; set; }

    }
    public class ListOfPagesRequest : PortalRequest
    {
        public int portal_id { get; set; }
    }


    public class DeletePortalRequest
    {
        public int portal_id { get; set; }
    }

}
