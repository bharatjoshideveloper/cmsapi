using Mvc_CmsWebapi.CommonLayer.Model.Inquiry;
using System.Data.SqlClient;

namespace Mvc_CmsWebapi.RepositoryLayer.Inquiry
{
    public class CustomerSendInquiryRL : ICustomerSendInquiryRL
    {
            public readonly IConfiguration _configuration;
            public readonly SqlConnection _sqlConnection;

            public CustomerSendInquiryRL(IConfiguration configuration)
            {
                _configuration = configuration;
                _sqlConnection = new SqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);
            }
       
       
        public async Task<CustomerSendInquiryResponse> CustomerSendInquiry(Request<CustomerSendInquiryRequest> request)
        {
            CustomerSendInquiryResponse response = new CustomerSendInquiryResponse();
            response.Issuccess = true;
            response.Message = "success";
            try

            {
                string query = "Insert into inquiry (fnm,lnm,address,city,state,pincode,country,email,contact_number,newsletter,comments) values (@fnm,@lnm,@address,@city,@state,@pincode,@country,@email,@contact_number,@newsletter,@comments)";
                using (SqlCommand sqlCommand = new SqlCommand(query, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@fnm", request.request.fnm);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@lnm", request.request.lnm);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@address", request.request.address);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@city", request.request.city);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@state", request.request.state);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@pincode", request.request.pincode);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@country", request.request.country);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@email", request.request.email);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@contact_number", request.request.contact_number);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@newsletter", request.request.newsletter);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@comments", request.request.comments);



                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.Issuccess = false;
                        response.Message = "An error occured while adding record in Admin";
                    }
                }

            }
            catch (Exception ex)
            {
                response.Issuccess = false;
                response.Message = "An error occured while adding record in Admin. The error is : " + ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;
        }
    }
}
