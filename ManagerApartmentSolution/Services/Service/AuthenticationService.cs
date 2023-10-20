

using Services.Models.Request;
using Services.Models.Response;

namespace Services.Servicess
{

    public interface AuthenticationService
    {
        Task<LoginResponse> ValidateStaff(RequestLogin accountLogin);
        Task<LoginResponse> ValidateOwner(RequestLogin accountLogin);
        Task<LoginResponse> ValidateTennant(RequestLogin accountLogin);
        Task<Boolean> Logout(int accountId);


        //Task<bool> ForgetPassword(string email);
        //Task<bool> ResetPassword(string email, string password, string resetToken);

    }
}