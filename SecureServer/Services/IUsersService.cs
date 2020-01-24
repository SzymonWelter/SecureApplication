using System.Threading.Tasks;
using SecureServer.Models.Domain;

namespace SecureServer.Services
{
    public interface IUsersService
    {
        Task<RequestResultModel> CreateUser(UserModel userModel);
    }
}