using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public readonly UserService _userService;

        public UserController(UserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }
    }
}
