using Mvc_CmsWebapi.CommonLayer.Model;
using System.Data.SqlClient;

namespace Mvc_CmsWebapi.RepositoryLayer
{
    public class AdminViewInquiryRL : IAdminViewInquiryRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;

        public AdminViewInquiryRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);
        }
        public async Task<ViewInquiry> AdminViewInquiry()
        {

            ViewInquiry response = new ViewInquiry();
            response.Issuccess = true;
            response.Message = "Successfull";
            try
            {

                string query = "select * from inquiry";
                using (SqlCommand sqlCommand = new SqlCommand(query, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    _sqlConnection.Open();

                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            response.adminViewInquiryResponses = new List<AdminViewInquiryResponse>();

                            while (await sqlDataReader.ReadAsync())
                            {
                                AdminViewInquiryResponse dbData = new AdminViewInquiryResponse();
                                dbData.inquiry_id = sqlDataReader[name: "inquiry_id"] != DBNull.Value ? Convert.ToInt32(sqlDataReader[name: "inquiry_id"]) : 0;
                                dbData.fnm = sqlDataReader[name: "fnm"] != DBNull.Value ? sqlDataReader[name: "fnm"].ToString() : string.Empty;
                                dbData.lnm = sqlDataReader[name: "lnm"] != DBNull.Value ? sqlDataReader[name: "lnm"].ToString() : string.Empty;
                                dbData.address = sqlDataReader[name: "address"] != DBNull.Value ? sqlDataReader[name: "address"].ToString() : string.Empty;
                                dbData.city = sqlDataReader[name: "city"] != DBNull.Value ? sqlDataReader[name: "city"].ToString() : string.Empty;
                                dbData.state = sqlDataReader[name: "state"] != DBNull.Value ? sqlDataReader[name: "state"].ToString() : string.Empty;
                                dbData.pincode = sqlDataReader[name: "pincode"] != DBNull.Value ? sqlDataReader[name: "pincode"].ToString() : string.Empty;
                                dbData.country = sqlDataReader[name: "country"] != DBNull.Value ? sqlDataReader[name: "country"].ToString() : string.Empty;
                                dbData.email = sqlDataReader[name: "email"] != DBNull.Value ? sqlDataReader[name: "email"].ToString() : string.Empty;
                                dbData.contact_number = sqlDataReader[name: "contact_number"] != DBNull.Value ? sqlDataReader[name: "contact_number"].ToString() : string.Empty;
                                dbData.newsletter = sqlDataReader[name: "newsletter"] != DBNull.Value ? sqlDataReader[name: "newsletter"].ToString() : string.Empty;
                                dbData.comments = sqlDataReader[name: "comments"] != DBNull.Value ? sqlDataReader[name: "comments"].ToString() : string.Empty;


                                response.adminViewInquiryResponses.Add(dbData);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Issuccess = false;
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
