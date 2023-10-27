

using Services.Models.Request;
using Services.Models.Response.Response;
using Services.Models.Response.Response.OwnerResponse;
using Services.Models.Response.Response.StaffResponse;
using Services.Models.Response.Response.TennantResponse;

namespace Services.Servicess
{

    public interface AuthenticationService
    {
        Task<AuthResponse<ResponseAccountStaff>> ValidateStaff(RequestLogin accountLogin);
        Task<AuthResponse<ResponseAccountOwner>> ValidateOwner(RequestLogin accountLogin);
        Task<AuthResponse<ResponseAccountTennant>> ValidateTennant(RequestLogin accountLogin);
        Task<AuthResponse<AccountResponse>> Validate(RequestLogin accountLogin);
        Task<AuthResponse<AccountResponse>> ValidateToken(string token);
        Task<Boolean> Logout(int accountId);


        //Task<bool> ForgetPassword(string email);
        //Task<bool> ResetPassword(string email, string password, string resetToken);

    }
}