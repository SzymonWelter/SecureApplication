using System.Threading.Tasks;
using SecureServer.Models.Domain;

namespace SecureServer.Services
{
    public interface IAuthService
    {
        Task<AuthResultModel> Authenticate (UserModel userModel);
    }
}