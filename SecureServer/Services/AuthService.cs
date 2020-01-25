using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SecureServer.Models.DAL;
using SecureServer.Models.Domain;
using Server.DAO;

namespace SecureServer.Services
{
    internal class AuthService : IAuthService
    {
        private readonly SecureContext _context;
        private readonly IMapService _mapService;
        private readonly IConfiguration _configuration;

        public AuthService(SecureContext context, IMapService mapService, IConfiguration configuration)
        {
            _context = context;
            _mapService = mapService;
            _configuration = configuration;
        }

        public async Task<AuthResultModel> Authenticate(UserModel userModel)
        {
            var users = _context.Users.Where(u => u.Username == userModel.Username);
            if (UserDoesntExists(users))
            {
                return UserDoesntExistsResult();
            }
            var user = users.First();
            if (UserIsBlocked(user))
            {
                return UserIsBlockedResult(user);
            }
            /// hash password
            /// Encode(userModel)
            if (PasswordsDontEquals(userModel, user))
            {
                await NoteWrongAttempt(user);
                return WrongPasswordResult(user.UserId);
            }
            return SuccessResult(user.UserId);
        }

        private AuthResultModel SuccessResult(Guid userId)
        {
            var token = GenerateToken(userId.ToString());
            return new AuthResultModel
            {
                IsSuccess = true,
                Token = token,
                UserId = userId
            };
        }

        private string GenerateToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Authorization:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, userId),
                }),
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static AuthResultModel WrongPasswordResult(Guid userId)
        {
            return new AuthResultModel
            {
                IsSuccess = false,
                Message = "Wrong password",
                UserId = userId
            };
        }

        private static AuthResultModel UserIsBlockedResult(UserDAL user)
        {
            return new AuthResultModel
            {
                IsSuccess = false,
                Message = $"Your account is blocked until {((DateTime)user.Blockade).ToString("t")}",
                UserId = user.UserId
            };
        }

        private bool UserIsBlocked(UserDAL user)
        {
            if (user.Blockade == null)
            {
                return false;
            }
            if (user.Blockade <= DateTime.UtcNow)
            {
                user.Blockade = null;
                return false;
            }
            return true;
        }

        private async Task NoteWrongAttempt(UserDAL user)
        {
            user.Attempt++;
            if (user.Attempt == 3)
            {
                user.Attempt = 0;
                user.Blockade = DateTime.UtcNow.AddMinutes(5);
            }
            await _context.SaveChangesAsync();

        }

        private bool PasswordsDontEquals(UserModel userModel, UserDAL user)
        {
            return user.Password != userModel.Password;
        }

        private AuthResultModel UserDoesntExistsResult()
        {
            return new AuthResultModel
            {
                IsSuccess = false,
                Message = "User doesnt exists"
            };
        }

        private static bool UserDoesntExists(IQueryable<UserDAL> users)
        {
            return users.Count() == 0;
        }
    }
}