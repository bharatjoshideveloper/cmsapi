using Mvc_CmsWebapi.CommonLayer.Model.Inquiry;

namespace Mvc_CmsWebapi.RepositoryLayer.Pages
{
    public interface IPagesRL
    {
        public Task<PagesResponse> CreatePage(PagesRequest request);

        public Task<PagesList> ListofPages();
        public Task<PagesList> EditPage(ListOfPagesRequest request);

        public Task<DetailOfPagesResponse> DetailPage(DetailOfPagesRequest request);

        public Task<PagesResponse> DeletePage(DetailOfPagesRequest request);
    }
}
