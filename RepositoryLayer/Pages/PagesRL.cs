using Mvc_CmsWebapi.CommonLayer.Model.Inquiry;
using System.Data.SqlClient;
using Dapper;

namespace Mvc_CmsWebapi.RepositoryLayer.Pages
{
    public class PagesRL : IPagesRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;

        public PagesRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);
        }
public async Task<PagesResponse> CreatePage(PagesRequest request)
        {
            PagesResponse response = new PagesResponse();
            response.message = "success";
            response.Success=true;
            try
            {
               

                string qry = "insert into page (portal_id,page_name,page_title,content) values(@portal_id,@page_name,@page_title,@content)";
                using (SqlCommand cmd = new SqlCommand(qry,_sqlConnection))
                {


                    cmd.CommandType=System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue(parameterName: "@portal_id", request.portal_id);
                    cmd.Parameters.AddWithValue(parameterName: "@page_name", request.page_name);
                    cmd.Parameters.AddWithValue(parameterName: "@page_title", request.page_title);
                    cmd.Parameters.AddWithValue(parameterName: "@content", request.content);
                    _sqlConnection.Open();
                    int status = await cmd.ExecuteNonQueryAsync();
                    if(status<=0)
                    {
                        response.Success=false;
                        response.message="error";
                    }
                }
            }
            catch(Exception ex)
            { 
                response.message = "error";
                response.Success = false;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<PagesList> ListofPages()
        {
            PagesList responce = new PagesList();
            responce.message = "success";
            responce.Success = true;
            try 
            {
                using (var con = _sqlConnection)
                {
                    var sql = "select * from page";
                    responce.listOfPagesRequests = (await con.QueryAsync<ListOfPagesRequest>(sql)).ToList();

                    return responce;
                }
            }
            catch(Exception ex)
            {
            }
            finally
                {
                _sqlConnection.Close();
            }
            return responce;
        }

        public async Task<PagesList> EditPage(ListOfPagesRequest request)
        {
            PagesList response = new PagesList();
            response.message = "success";
            response.Success = true;
            using (var con = _sqlConnection)
            {
                var qry = await con.ExecuteAsync(@"update page set portal_id=@portal_id,page_name=@page_name,page_title=@page_title,
                content=@content where page_id=@page_id;",
                new
                {
                    page_id = request.page_id,
                    portal_id=request.portal_id,
                    page_name = request.page_name,
                    page_title = request.page_title,
                    content = request.content
                });
            }
            return response;
        }

        public async Task<DetailOfPagesResponse> DetailPage(DetailOfPagesRequest request)
        {
            int page_id = request.page_id;

            DetailOfPagesResponse response = new DetailOfPagesResponse();
            using(var con=_sqlConnection)
            {
               string  qry = "select * from page where page_id="+page_id;
                response = (await con.QueryFirstOrDefaultAsync<DetailOfPagesResponse>(qry));
                return response;    
            }
        }
        public async Task<PagesResponse> DeletePage(DetailOfPagesRequest request)
        {
            int page_id=request.page_id;
            PagesResponse response = new PagesResponse();
            response.message="success";
            response.Success = true;
            using(var con = _sqlConnection)
            {
               var r1 = (await con.ExecuteAsync(@"delete from page where page_id=@page_id;", new { page_id }));
            }
            return response;
        }
    }
}
