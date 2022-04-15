using Mvc_CmsWebapi.CommonLayer.Model.Inquiry;
using Mvc_CmsWebapi.RepositoryLayer.Pages;

namespace Mvc_CmsWebapi.ServiceLayer.Pages
{
    public class PagesSL : IPagesSL
    {
        public readonly IPagesRL _pagesRL;
        public PagesSL(IPagesRL pagesRL)
        {
            _pagesRL = pagesRL;
        }

        public async Task<PagesResponse> CreatePage(PagesRequest request)
        {
            return await _pagesRL.CreatePage(request);
        }

        public async Task<PagesResponse> DeletePage(DetailOfPagesRequest request)
        {
            return await _pagesRL.DeletePage(request);
        }

        public async Task<DetailOfPagesResponse> DetailPage(DetailOfPagesRequest request)
        {
            return await _pagesRL.DetailPage(request);
        }

        public async Task<PagesList> EditPage(ListOfPagesRequest request)
        {
            return await _pagesRL.EditPage(request);
        }

        public async Task<PagesList> ListofPages()
        {
            return await _pagesRL.ListofPages();
        }


    }
}
