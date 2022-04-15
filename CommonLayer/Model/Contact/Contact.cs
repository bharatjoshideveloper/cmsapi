namespace Mvc_CmsWebapi.CommonLayer.Model.Contact
{
    public class ContactRequest
    {
        public int portal_id { get; set; }
        public string page_title { get; set; }
        public string company_name { get; set; }
        public string contact_number { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string detail { get; set; }
    }
    public class ContactResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
    }

       public class Request<T>
        {
            public T? request { get; set; }
        }

    public class ContactUpdateRequest:ContactRequest
    {
        public int contact_id { get; set; }
    }

}
