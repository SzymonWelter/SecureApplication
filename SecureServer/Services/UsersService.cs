using System;
using System.Linq;
using System.Threading.Tasks;
using SecureServer.Models.Domain;
using Server.DAO;

namespace SecureServer.Services
{
    internal class UsersService : IUsersService
    {
        private readonly SecureContext _context;
        private readonly IMapService _mapService;

        public UsersService(SecureContext context, IMapService mapService)
        {
            _context = context;
            _mapService = mapService;
        }

        public async Task<RequestResultModel> CreateUser(UserModel userModel)
        {
            userModel.UserId = Guid.NewGuid();
            var userDAL = _mapService.Map(userModel);
            if (UsernameAlreadyExists(userModel.Username))
            {
                return UsernameAlreadyExistsResult();
            }

            await _context.Users.AddAsync(userDAL);
            await _context.SaveChangesAsync();

            return SuccessResult();
        }

        private static RequestResultModel SuccessResult()
        {
            return new RequestResultModel
            {
                IsSuccess = true,
            };
        }

        private RequestResultModel UsernameAlreadyExistsResult()
        {
            return new RequestResultModel
            {
                IsSuccess = false,
                Message = "User with provided username already exists"
            };
        }

        private bool UsernameAlreadyExists(string username)
        {
            return _context.Users
                .Where(u => u.Username == username)
                .Count() > 0;
        }
    }
}