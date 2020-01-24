using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecureServer.Models.Domain;
using SecureServer.Models.DTO;
using SecureServer.Services;

namespace SecureServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapService _mapService;

        public AuthController(IAuthService authService, IMapService mapService)
        {
            _authService = authService;
            _mapService = mapService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthResultModel>> Authenticate([FromForm] SignInDTO signInDTO)
        {
            var userModel = _mapService.Map(signInDTO);
            var result = _authService.Authenticate(userModel);

            var resultDTO = _mapService.Map(result);
            Response.Cookies.Append("AuthToken", result.Token, new CookieOptions{ Path="/", HttpOnly=true, Expires=new DateTimeOffset(DateTime.UtcNow, TimeSpan.FromMinutes(5)),Secure=true });
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            return await Task.Run(() =>
            {
                var cookies = Request.Cookies;
                Console.WriteLine(cookies);
                return Ok();
            });

        }
    }
}