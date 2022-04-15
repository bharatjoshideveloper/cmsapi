namespace Mvc_CmsWebapi.CommonLayer.Model
{

    public class AdminDetailResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }

        public List<AdminDetailData>? adminDetailData { get; set; }
    }

    public class AdminDetailRequest
    {
        public int admin_id { get; set; }

    }
    public class AdminDetailData
    {
        public int admin_id { get; set; }

        public string? first_nm { get; set; }

        public string? last_nm { get; set; }

        public string? site_url { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public string? company_nm { get; set; }
        public string? mobile_num { get; set; }
        public string? country { get; set; }
        public string? currency { get; set; }
        public string? languages { get; set; }
    }
   
}
