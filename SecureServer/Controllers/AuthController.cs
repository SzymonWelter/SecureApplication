using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecureServer.Models.Domain;
using SecureServer.Models.DTO;
using SecureServer.Services;

namespace SecureServer.Controllers
{
    [AllowAnonymous]
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
        public async Task<ActionResult<RequestResultDTO>> Authenticate([FromForm] SignInDTO signInDTO)
        {
            var userModel = _mapService.Map(signInDTO);
            var result = await _authService.Authenticate(userModel);

            var resultDTO = _mapService.Map(result);
            if (!resultDTO.IsSuccess)
            {
                return BadRequest(resultDTO);
            }
            Response.Cookies.Append("authToken", result.Token, new CookieOptions { Path = "/", HttpOnly = true, Expires = DateTime.UtcNow.AddMinutes(5), Secure = true, SameSite = SameSiteMode.Strict });
            Response.Cookies.Append("user", result.UserId.ToString(), new CookieOptions { Path = "/", HttpOnly = false, Expires = DateTime.UtcNow.AddMinutes(5), SameSite = SameSiteMode.Strict });
            return Ok(resultDTO);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            Response.Cookies.Append("authToken", "", new CookieOptions { Path = "/", HttpOnly = true, Expires = DateTime.UtcNow.AddDays(-2), Secure = true, SameSite = SameSiteMode.Strict });
            Response.Cookies.Append("user", "", new CookieOptions { Path = "/", HttpOnly = false, Expires = DateTime.UtcNow.AddDays(-2), SameSite = SameSiteMode.Strict });

            return await Task.Run(() =>
            {
                return Ok();
            });

        }
    }
}