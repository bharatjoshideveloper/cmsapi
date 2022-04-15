using Mvc_CmsWebapi.CommonLayer.Model.Deals;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace Mvc_CmsWebapi.RepositoryLayer.Deals
{
    public class DealsAddRL : IDealsAddRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;
      public DealsAddRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);
        }

        public async Task<DealsAddResponse> CreateDeals(Request<DealsAddRequest> request)
        {
            DealsAddResponse response = new DealsAddResponse();
            response.message = "success";
            response.Issuccess = true;
            try
            {
                string qry = "insert into deals (portal_id,deals_type,title,image_url,price,description,overview,inclusion,exclusion,terms_condition)" +
                    "values(@portal_id,@deals_type,@title,@image_url,@price,@description,@overview,@inclusion,@exclusion,@terms_condition)";
                using (SqlCommand sqlCommand = new SqlCommand(qry, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@portal_id", request.request.portal_id);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@deals_type", request.request.deals_type);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@title", request.request.title);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@image_url", request.request.image_url);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@price", request.request.price);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@description", request.request.description);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@overview", request.request.overview);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@inclusion", request.request.inclusion);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@exclusion", request.request.exclusion);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@terms_condition", request.request.terms_condition);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.Issuccess = false;
                        response.message = "Error";
                    }

                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.Issuccess = false;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<DeleteDealsResponse> DeleteDeals(DeleteDealRequest request)
        {

            DeleteDealsResponse response = new DeleteDealsResponse();
            response.message = "success";
            response.Issuccess = true;
            try
            {
                string qry = "Delete from deals where deals_id=@deals_id";
                using (SqlCommand sql = new SqlCommand(qry, _sqlConnection))
                {
                    sql.CommandType = System.Data.CommandType.Text;
                    sql.CommandTimeout = 180;
                    sql.Parameters.AddWithValue(parameterName: "deals_id", request.deals_id);
                    _sqlConnection.Open();
                    int status = await sql.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.Issuccess = false;
                        response.message = "Error";
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.Issuccess = false;
            }
            finally
            {
                _sqlConnection.Close();

            }
            return response;
        }

        //Using Dapper Deals List
        public async Task<ListOfDeals> ListDeals()
        {
            ListOfDeals response = new ListOfDeals();
            response.Issuccess = true;
            response.message = "success";

            using (var con = _sqlConnection)
            {
                var sql = "select * from deals";
                response.listOfDealsResponse = (await con.QueryAsync<ListOfDealsResponse>(sql)).ToList();

                return response;
            }
        }

        public async Task<Response<DealsOfDetailResponse>> DealsDetail(Request<DealsOfDetailRequest> request)
        {
            int deals_id = request.request.deals_id;
            Response<DealsOfDetailResponse> response = new Response<DealsOfDetailResponse>();
        
            using (var con=_sqlConnection)
            {
                var sql = "select * from deals where deals_id=" + deals_id;
                response = await con.QueryFirstOrDefaultAsync<Response<DealsOfDetailResponse>>(sql);
              
                return response;
            }
        }
        public async Task<UpdateDealsResponse> UpdateDeals(UpdateDealsRequest request)
        {
            UpdateDealsResponse response = new UpdateDealsResponse();
            response.message = "success";
            response.Issuccess = true;
            try
            {
                string qry = "update deals set portal_id=@portal_id,deals_type=@deals_type,title=@title,image_url=@image_url," +
                    "price=@price,description=@description,overview=@overview,inclusion=@inclusion,exclusion=@exclusion,terms_condition=@terms_condition where deals_id=@deals_id";
                using (SqlCommand sql = new SqlCommand(qry, _sqlConnection))
                {
                    sql.CommandType = System.Data.CommandType.Text;
                    sql.CommandTimeout = 180;
                    sql.Parameters.AddWithValue(parameterName: "@portal_id", request.portal_id);
                    sql.Parameters.AddWithValue(parameterName: "@deals_type", request.deals_type);
                    sql.Parameters.AddWithValue(parameterName: "@title", request.title);
                    sql.Parameters.AddWithValue(parameterName: "@image_url", request.image_url);
                    sql.Parameters.AddWithValue(parameterName: "@price", request.price);
                    sql.Parameters.AddWithValue(parameterName: "@description", request.description);
                    sql.Parameters.AddWithValue(parameterName: "@overview", request.overview);
                    sql.Parameters.AddWithValue(parameterName: "@inclusion", request.inclusion);
                    sql.Parameters.AddWithValue(parameterName: "@exclusion", request.exclusion);
                    sql.Parameters.AddWithValue(parameterName: "@terms_condition", request.terms_condition);
                    sql.Parameters.AddWithValue(parameterName: "@deals_id", request.deals_id);

                    _sqlConnection.Open();
                    int status = await sql.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.message = "something went wrong";
                        response.Issuccess = false;
                    }
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.Issuccess = false;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }



        /*public async Task<ListOfDeals> ListDeals()
        {
            
           ListOfDeals response = new ListOfDeals();
           response.Issuccess = true;
           response.message = "success";
           try
           {
               string qry = "select * from Deals";
               using (SqlCommand sql = new SqlCommand(qry, _sqlConnection))
               {
                   sql.CommandType = System.Data.CommandType.Text;
                   sql.CommandTimeout = 180;
                   _sqlConnection.Open();
                   using (SqlDataReader sqlreader = await sql.ExecuteReaderAsync())
                   {
                       if (sqlreader.HasRows)
                       {
                           response.listOfDealsResponse = new List<ListOfDealsResponse>();
                           while (await sqlreader.ReadAsync())
                           {
                               ListOfDealsResponse dbData = new ListOfDealsResponse();
                               dbData.admin_id = sqlreader[name: "admin_id"] != DBNull.Value ? Convert.ToInt32(sqlreader[name: "admin_id"]) : 0;
                               dbData.deals_id = sqlreader[name: "deals_id"] != DBNull.Value ? Convert.ToInt32(sqlreader[name: "deals_id"]) : 0;
                               dbData.deals_type = sqlreader[name: "deals_type"] != DBNull.Value ? sqlreader[name: "deals_type"].ToString() : string.Empty;
                               dbData.title = sqlreader[name: "title"] != DBNull.Value ? sqlreader[name: "title"].ToString() : string.Empty;
                               dbData.image_url = sqlreader[name: "image_url"] != DBNull.Value ? sqlreader[name: "image_url"].ToString() : string.Empty;
                               dbData.price = sqlreader[name: "price"] != DBNull.Value ? sqlreader[name: "price"].ToString() : string.Empty;
                               dbData.description = sqlreader[name: "description"] != DBNull.Value ? sqlreader[name: "description"].ToString() : string.Empty;
                               dbData.overview = sqlreader[name: "overview"] != DBNull.Value ? sqlreader[name: "overview"].ToString() : string.Empty;
                               dbData.inclusion = sqlreader[name: "inclusion"] != DBNull.Value ? sqlreader[name: "inclusion"].ToString() : string.Empty;
                               dbData.exclusion = sqlreader[name: "exclusion"] != DBNull.Value ? sqlreader[name: "exclusion"].ToString() : string.Empty;
                               dbData.terms_condition = sqlreader[name: "terms_condition"] != DBNull.Value ? sqlreader[name: "terms_condition"].ToString() : string.Empty;
                               response.listOfDealsResponse.Add(dbData);
                           }
                       }
                   }
               }
           }
           catch (Exception ex)
           {
               response.message = ex.Message;
               response.Issuccess = false;
           }
           finally
           {
               _sqlConnection.Close();
           }

           return response;*/
    }        
        #region Code comment

        /*
        public async Task<ListOfDeals> ListDeals()
        {

            Response<List<ListOfDeals>> response = new Response<List<ListOfDeals>>();
            response.Success = true;
            response.Message = "Successfull";

            var sql = "SELECT * FROM Deals";
            using (var connection = new SqlConnection(_configuration["ConnectionStrings:DBSettingConnection"]))
            {
                connection.Open();
                var result = (await connection.QueryAsync<ListOfDeals>(sql)).ToList();
                return result;
            }
        }
        */

        #endregion Code comment
}

