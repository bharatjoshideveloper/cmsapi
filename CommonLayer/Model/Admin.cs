using System.ComponentModel.DataAnnotations;

namespace Mvc_CmsWebapi.CommonLayer.Model
{
    public class Admin
    {
        //internal int admin_id;
        public int admin_id;
        public string? first_nm { get; set; }
        public string? last_nm { get; set;}  
        public string? site_url { get;set; }
        public string? password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? email { get; set; }
        public string? company_nm { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? mobile_num { get; set; }
        public string? country { get; set; }
        public string? currency { get; set; }
        public string? languages { get; set; }
    }
    public class CreateRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }


    public class Request<T>
    {
        public T ?request { get; set; }
    }

    public class Response<T>
    {
        public T? response { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Warning { get; set; }
    }

}
