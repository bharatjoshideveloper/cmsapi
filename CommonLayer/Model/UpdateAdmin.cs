namespace Mvc_CmsWebapi.CommonLayer.Model
{
    public class UpdateAdminRequest : AdminDetailData
    {
      
    }
    public class UpdateAdminResponse
    {
        public bool Success { get; set; }   
        public string? Message { get; set; } 
    }
}
