using Mvc_CmsWebapi.CommonLayer.Model.Contact;

namespace Mvc_CmsWebapi.RepositoryLayer.Contact
{
    public interface IContactRL
    {
        public Task<ContactResponse> Addcontact(Request<ContactRequest> request);
        public Task<ContactResponse> Updatecontact(Request<ContactUpdateRequest> request);

    }
}
