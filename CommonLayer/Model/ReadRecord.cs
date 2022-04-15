namespace Mvc_CmsWebapi.CommonLayer.Model
{
    public class ReadRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }

        public List<ReadRecordData>? readRecordData { get; set; }
    }
    public class ReadRecordData : AdminDetailData
    {
        
    }
}
