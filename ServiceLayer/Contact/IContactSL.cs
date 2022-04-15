using Mvc_CmsWebapi.CommonLayer.Model.Contact;

namespace Mvc_CmsWebapi.ServiceLayer.Contact
{
    public interface IContactSL
    {
        public Task<ContactResponse> Addcontact(Request< ContactRequest> request);
        public Task<ContactResponse> Updatecontact(Request<ContactUpdateRequest> request);

    }
}
