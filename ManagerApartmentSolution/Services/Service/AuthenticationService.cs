

namespace Services.Servicess
{

    public interface AuthenticationService
    {
        Task<bool> ForgetPassword(string email);
        Task<bool> ResetPassword(string email, string password, string resetToken);

    }
}