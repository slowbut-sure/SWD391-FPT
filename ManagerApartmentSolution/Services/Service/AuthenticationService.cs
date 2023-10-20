

using Services.Models.Request;
using Services.Models.Response;
using Services.Models.Response.OwnerResponse;
using Services.Models.Response.StaffResponse;
using Services.Models.Response.TennantResponse;

namespace Services.Servicess
{

    public interface AuthenticationService
    {
        Task<LoginResponse<ResponseAccountStaff>> ValidateStaff(RequestLogin accountLogin);
        Task<LoginResponse<ResponseAccountOwner>> ValidateOwner(RequestLogin accountLogin);
        Task<LoginResponse<ResponseAccountTennant>> ValidateTennant(RequestLogin accountLogin);
        Task<Boolean> Logout(int accountId);


        //Task<bool> ForgetPassword(string email);
        //Task<bool> ResetPassword(string email, string password, string resetToken);

    }
}