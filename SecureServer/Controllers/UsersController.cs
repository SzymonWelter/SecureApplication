using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecureServer.Models.DTO;
using SecureServer.Services;

namespace SecureServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapService _mapService;

        public UsersController(IUsersService usersService, IMapService mapService){
            _usersService = usersService;
            _mapService = mapService;
        }
        [HttpPost]
        public async Task<ActionResult<RequestResultDTO>> AddUser([FromForm] UserDTO userDTO){
            var userModel = _mapService.Map(userDTO);
            var result = await _usersService.CreateUser(userModel);
            var resultDTO = _mapService.Map(result);
            return Ok(resultDTO);
        }
    }
}