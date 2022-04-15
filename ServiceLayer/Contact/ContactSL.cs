using Mvc_CmsWebapi.CommonLayer.Model.Contact;
using Mvc_CmsWebapi.RepositoryLayer.Contact;

namespace Mvc_CmsWebapi.ServiceLayer.Contact
{
    public class ContactSL : IContactSL
    {
        public readonly IContactRL  _contactRL;
        public ContactSL(IContactRL contactRL)
        {
            _contactRL = contactRL;
        }
        
        public async Task<ContactResponse> Addcontact(Request< ContactRequest> request)
        {
            return await _contactRL.Addcontact(request);
        }

        public async Task<ContactResponse> Updatecontact(Request<ContactUpdateRequest> request)
        {
            return await _contactRL.Updatecontact(request);
        }
    }
}
