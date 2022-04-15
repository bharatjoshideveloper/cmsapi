namespace Mvc_CmsWebapi.CommonLayer.Model
{
    public class DeleteAdminRequest
    {
        public int admin_id { get; set; }

    }
    public class DeleteAdminResponse
    {
        public bool success { get; set; }   
        public string? message { get; set; } 

    }
}
