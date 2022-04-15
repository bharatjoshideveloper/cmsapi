using Mvc_CmsWebapi.CommonLayer.Model.Portals;
using System.Data.SqlClient;
using Dapper;
namespace Mvc_CmsWebapi.RepositoryLayer.Portal
{
    public class PortalRL : IPortalRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;

        public PortalRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);
        }

        public async Task<PortalResponse> AddPortal(PortalRequest request)
        {
            PortalResponse response = new PortalResponse();
            response.message = "success";
            response.success = true;
            using(var con=_sqlConnection)
            { 
                var insertResult = await con.QueryAsync<int>(
                            @"INSERT INTO portal ([site_url],[name],[email],[contactno],[company_name],[logo],[currency],[languages],[isactive]) 
                OUTPUT Inserted.portal_id 
                VALUES (@site_url, @name, @email, @contactno,@company_name,@logo,@currency,@languages,@isactive);",
                        new
                        {
                            site_url = request.site_url,
                            name = request.name,
                            email = request.email,
                            contactno = request.contactno,
                            company_name=request.company_name,
                            logo=request.logo,
                            currency=request.currency,
                            languages=request.languages,
                            isactive=request.isactive
                        });

                        int portal_id = insertResult.Single();
                    }

                    return response;
        }

        public async Task<PortalResponse> UpdatePortal(UpdateRequest request)
        {
            PortalResponse response = new PortalResponse();
            response.message = "success";
            response.success = true;
            using(var con=_sqlConnection)
            {
                var qry = await con.ExecuteAsync(@"update portal set site_url=@site_url,name=@name,email=@email,contactno=@contactno,
                company_name=@company_name,logo=@logo,currency=@currency,languages=@languages,isactive=@isactive where portal_id=@portal_id;", new
                {
                    portal_id = request.portal_id,
                    site_url = request.site_url,
                    name = request.name,
                    email = request.email,
                    contactno = request.contactno,
                    company_name = request.company_name,
                    logo = request.logo,
                    currency = request.currency,
                    languages = request.languages,
                    isactive = request.isactive
                });

            }
            return response;
        }
        public async Task<PortalResponse> DeletePortal(DeletePortalRequest request)
        {
            int portal_id = request.portal_id;
            PortalResponse response = new PortalResponse();
            response.message="success";
            response.success=true;
            using(var con=_sqlConnection)
            {
                var qry = "Delete from portal where portal_id="+portal_id;
                var deleteportal = await con.ExecuteAsync(qry);

            }
            return response;
        }

        public async Task<PortalRequest> DetailPortal(DeletePortalRequest request)
        {
            int portal_id = request.portal_id;
            {
                using (var con = _sqlConnection)
                {
                    var qry = "select * from portal where portal_id=" + portal_id;
                    var res = (await con.QueryFirstOrDefaultAsync<PortalRequest>(qry));
                    return res;
                }
            }
        }

        public async Task<PagesList> Listofportal()
        {
            PagesList response = new PagesList();
            response.message = "Success";
            response.success = true;
            using (var con = _sqlConnection)
            {
                var query = "select * from portal";
                response.listOfPagesRequests = (await con.QueryAsync<ListOfPagesRequest>(query)).ToList();
                return response;
            }
        }
    }
}
