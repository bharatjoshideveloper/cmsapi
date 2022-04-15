using Dapper;
using Mvc_CmsWebapi.CommonLayer.Model.Contact;
using System.Data.SqlClient;

namespace Mvc_CmsWebapi.RepositoryLayer.Contact
{
    public class ContactRL : IContactRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;

        public ContactRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);
        }
        public async Task<ContactResponse> Addcontact(Request<ContactRequest> request)
        {
            ContactResponse response = new ContactResponse();
                response.message = "success";
                response.success = true;
                using (var con = _sqlConnection)
                {
                    var insertResult = await con.QueryAsync<int>(
                                @"INSERT INTO contact ([portal_id],[page_title],[company_name],[contact_number],[email],[address],[detail]) 
                OUTPUT Inserted.portal_id 
                VALUES (@portal_id, @page_title, @company_name, @contact_number,@email,@address,@detail);",
                            new
                            {
                                portal_id = request.request.portal_id,
                                page_title = request.request.page_title,
                                company_name = request.request.company_name,
                                contact_number = request.request.contact_number,
                                email = request.request.email,
                                address = request.request.address,
                                detail = request.request.detail
                            });

                }

                return response;
            }

        public async Task<ContactResponse> Updatecontact(Request<ContactUpdateRequest> request)
        {
            ContactResponse response = new ContactResponse();
            response.message = "success";
            response.success = true;
            using ( var con=_sqlConnection)

            {
                var qry = await con.ExecuteAsync(@"update contact set portal_id=@portal_id,page_title=@page_title,
        company_name=@company_name,contact_number=@contact_number,email=@email,address=@address,detail=@detail where contact_id=@contact_id;", new
                {
                    portal_id = request.request.portal_id,
                    page_title = request.request.page_title,
                    company_name = request.request.company_name,
                    contact_number = request.request.contact_number,
                    email = request.request.email,
                    address = request.request.address,
                    detail = request.request.detail,

                });

            }
            return response;
        }
    }

       
    }

