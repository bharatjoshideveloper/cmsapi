using Mvc_CmsWebapi.CommonLayer.Model;
using System.Data.SqlClient;

namespace Mvc_CmsWebapi.RepositoryLayer
{
    public class AdminRL : IAdminRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;

        public AdminRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);
        }
        // Detail of specific admin

        public async Task<AdminDetailResponse> AdminDetail(AdminDetailRequest request)
        {
           int admin_id = request.admin_id;

                AdminDetailResponse response = new AdminDetailResponse();
                response.IsSuccess = true;
                response.Message = "Successfull";
                try
                {

                    string query = "Select * From admin Where admin_id="+admin_id;
                    using (SqlCommand sqlCommand = new SqlCommand(query, _sqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 180;
                        _sqlConnection.Open();

                        using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                        {
                            if (sqlDataReader.HasRows)
                            {
                                response.adminDetailData = new List<AdminDetailData>();

                                while (await sqlDataReader.ReadAsync())
                                {
                                AdminDetailData dbData = new AdminDetailData();
                                    dbData.admin_id = sqlDataReader[name: "admin_id"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "admin_id"]) : 0;
                                    dbData.first_nm = sqlDataReader[name: "first_nm"] != DBNull.Value ? sqlDataReader[name: "first_nm"].ToString() : string.Empty;
                                    dbData.last_nm = sqlDataReader[name: "last_nm"] != DBNull.Value ? sqlDataReader[name: "last_nm"].ToString() : string.Empty;
                                    dbData.site_url = sqlDataReader[name: "site_url"] != DBNull.Value ? sqlDataReader[name: "site_url"].ToString() : string.Empty;
                                    dbData.password = sqlDataReader[name: "password"] != DBNull.Value ? sqlDataReader[name: "password"].ToString() : string.Empty;
                                    dbData.email = sqlDataReader[name: "email"] != DBNull.Value ? sqlDataReader[name: "email"].ToString() : string.Empty;
                                    dbData.company_nm = sqlDataReader[name: "company_nm"] != DBNull.Value ? sqlDataReader[name: "company_nm"].ToString() : string.Empty;
                                    dbData.mobile_num = sqlDataReader[name: "mobile_num"] != DBNull.Value ? sqlDataReader[name: "mobile_num"].ToString() : string.Empty;
                                    dbData.country = sqlDataReader[name: "country"] != DBNull.Value ? sqlDataReader[name: "country"].ToString() : string.Empty;
                                    dbData.currency = sqlDataReader[name: "currency"] != DBNull.Value ? sqlDataReader[name: "currency"].ToString() : string.Empty;
                                    dbData.languages = sqlDataReader[name: "languages"] != DBNull.Value ? sqlDataReader[name: "languages"].ToString() : string.Empty;


                                    response.adminDetailData.Add(dbData);

                                }
                            }
                        }
                    }
                }
             
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = ex.Message;
                }
                finally
                {
                    _sqlConnection.Close();
                }
                return response;
            }

        


        // Insert Admin
        public async Task<CreateRecordResponse> CreateRecord(Request<Admin> request)
        {
            CreateRecordResponse response   = new CreateRecordResponse();
            response.IsSuccess = true;
            response.Message = "success";
            try

            {
                string query = "Insert into admin (first_nm,last_nm,site_url,password,email,company_nm,mobile_num,country,currency,languages) values (@first_nm,@last_nm,@site_url,@password,@email,@company_nm,@mobile_num,@country,@currency,@languages)";
                using (SqlCommand sqlCommand=new SqlCommand(query,_sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@first_nm", request.request.first_nm);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@last_nm", request.request.last_nm);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@site_url", request.request.site_url);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@password", request.request.password);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@email", request.request.email);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@company_nm", request.request.company_nm);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@mobile_num", request.request.mobile_num);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@country", request.request.country);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@currency", request.request.currency);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@languages", request.request.languages);



                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if(status<=0)
                    {
                        response.IsSuccess = false;
                        response.Message = "An error occured while adding record in Admin";
                    }
                }

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "An error occured while adding record in Admin. The error is : " + ex.Message;
            }
            finally 
            {
                _sqlConnection.Close();
            }

            return response;
        }

        // Delete Admin
        public async Task<DeleteAdminResponse> DeleteAdmin(DeleteAdminRequest request)
        {
            DeleteAdminResponse response = new DeleteAdminResponse();
            response.success = true;
            response.message = "Delete Successfully";
            try
            {
                string qry = "Delete from admin where admin_id=@admin_id";
                using(SqlCommand sqlCommand=new SqlCommand(qry,_sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "admin_id", request.admin_id);
                    _sqlConnection.Open();
                    int status=await sqlCommand.ExecuteNonQueryAsync();
                    if(status<=0)
                    {
                        response.success = false;
                        response.message = "something went wrong";
                    }
                }
            }
            catch(Exception ex)
            {
                response.success = false;
                response.message = ex.Message;

            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        // List of Admin
        public async Task<ReadRecordResponse> ReadRecord()
        {

            ReadRecordResponse response=new ReadRecordResponse();
            response.IsSuccess=true;
            response.Message = "Successfull";
            try
            {

                string query = "select * from admin";
                using(SqlCommand sqlCommand=new SqlCommand(query, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();

                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync()) 
                    {
                        if (sqlDataReader.HasRows)
                        {
                            response.readRecordData=new List<ReadRecordData>();

                            while(await sqlDataReader.ReadAsync())
                            {
                                ReadRecordData dbData=new ReadRecordData();
                                dbData.admin_id = sqlDataReader[name: "admin_id"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "admin_id"]) : 0;
                                dbData.first_nm = sqlDataReader[name: "first_nm"] != DBNull.Value ? sqlDataReader[name: "first_nm"].ToString():string.Empty;
                                dbData.last_nm = sqlDataReader[name: "last_nm"] != DBNull.Value ? sqlDataReader[name: "last_nm"].ToString() : string.Empty;
                                dbData.site_url = sqlDataReader[name: "site_url"] != DBNull.Value ? sqlDataReader[name: "site_url"].ToString() : string.Empty;
                                dbData.password = sqlDataReader[name: "password"] != DBNull.Value ? sqlDataReader[name: "password"].ToString() : string.Empty;
                                dbData.email = sqlDataReader[name: "email"] != DBNull.Value ? sqlDataReader[name: "email"].ToString() : string.Empty;
                                dbData.company_nm = sqlDataReader[name: "company_nm"] != DBNull.Value ? sqlDataReader[name: "company_nm"].ToString() : string.Empty;
                                dbData.mobile_num = sqlDataReader[name: "mobile_num"] != DBNull.Value ? sqlDataReader[name: "mobile_num"].ToString() : string.Empty;
                                dbData.country = sqlDataReader[name: "country"] != DBNull.Value ? sqlDataReader[name: "country"].ToString() : string.Empty;
                                dbData.currency = sqlDataReader[name: "currency"] != DBNull.Value ? sqlDataReader[name: "currency"].ToString() : string.Empty;
                                dbData.languages = sqlDataReader[name: "languages"] != DBNull.Value ? sqlDataReader[name: "languages"].ToString() : string.Empty;


                                response.readRecordData.Add(dbData);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        // Update Admin
        public async Task<UpdateAdminResponse> UpdateAdmin(UpdateAdminRequest request)
        {
            UpdateAdminResponse response=new UpdateAdminResponse();
            response.Success = true;
            response.Message = "update Successfully";

            try
            {
                string qry = "update admin Set first_nm=@first_nm,last_nm=@last_nm,site_url=@site_url,password=@password," +
                    "email=@email,company_nm=@company_nm,mobile_num=@mobile_num,country=@country,currency=@currency,languages=@languages where admin_id =@admin_id";
                using (SqlCommand sqlCommand=new SqlCommand(qry,_sqlConnection))
                { 
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@first_nm", request.first_nm);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@last_nm", request.last_nm);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@admin_id", request.admin_id);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@site_url", request.site_url);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@password", request.password);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@email", request.email);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@company_nm", request.company_nm);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@mobile_num", request.mobile_num);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@country", request.country);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@currency", request.currency);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@languages", request.languages);

                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if(status<=0)
                    {
                        response.Success=false;
                        response.Message = "something went wrong";

                    }
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }
    }
}
