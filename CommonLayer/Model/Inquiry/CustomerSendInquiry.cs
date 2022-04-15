namespace Mvc_CmsWebapi.CommonLayer.Model.Inquiry
{
    public class CustomerSendInquiryRequest
    {
     
            public string ?fnm { get; set; }
            public string ?lnm { get; set; }
            public string ?address { get; set; }
            public string ?city { get; set; }
            public string ?state { get; set; }
            public string ?pincode { get; set; }
            public string ?country { get; set; }
            public string ?email { get; set; }
            public string ?contact_number { get; set; }
            public string ?newsletter { get; set; }
            public string ?comments { get; set; }

    }
    public class CustomerSendInquiryResponse
    {
        public bool Issuccess { get; set; }
        public string? Message { get; set; }
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
        public string? Warning { get; set; }
    }
}
