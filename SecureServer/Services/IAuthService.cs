using SecureServer.Models.Domain;

namespace SecureServer.Services
{
    public interface IAuthService
    {
        AuthResultModel Authenticate(UserModel userModel);
    }
}