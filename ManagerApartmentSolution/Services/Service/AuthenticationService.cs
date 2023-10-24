

using Services.Models.Request;
using Services.Models.Response;
using Services.Models.Response.OwnerResponse;
using Services.Models.Response.StaffResponse;
using Services.Models.Response.TennantResponse;

namespace Services.Servicess
{

    public interface AuthenticationService
    {
        Task<DataResponse<ResponseAccountStaff>> ValidateStaff(RequestLogin accountLogin);
        Task<DataResponse<ResponseAccountOwner>> ValidateOwner(RequestLogin accountLogin);
        Task<DataResponse<ResponseAccountTennant>> ValidateTennant(RequestLogin accountLogin);
        Task<DataResponse<AccountResponse>> Validate(RequestLogin accountLogin);
        Task<DataResponse<AccountResponse>> ValidateToken(string token);
        Task<Boolean> Logout(int accountId);


        //Task<bool> ForgetPassword(string email);
        //Task<bool> ResetPassword(string email, string password, string resetToken);

    }
}