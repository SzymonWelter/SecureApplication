using System;
using System.Linq;
using System.Security.Cryptography;
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
            if (UsernameAlreadyExists(userModel.Username))
            {
                return UsernameAlreadyExistsResult();
            }

            userModel.Password = EncodePassword(userModel.Password);
            var userDAL = _mapService.MapToDAL(userModel);
            await _context.Users.AddAsync(userDAL);
            await _context.SaveChangesAsync();

            return SuccessResult();
        }

        private string EncodePassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
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