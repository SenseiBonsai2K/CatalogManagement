using Application.DTOs;
using Application.Requests;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public readonly UserService _userService;
        public readonly JwtService JwtService;

        public UserController(UserService userService, JwtService tokenService)
        {
            this._userService = userService;
            JwtService = tokenService;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult> AddUser([FromBody] AddUserRequest addUserRequest)
        {
            var user = addUserRequest.ToEntity();
            try
            {
                await _userService.AddUser(user);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok(new { message = "Account " + user.Username + " Registered" });
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult> DeleteUser([FromQuery] int id)
        {
            var user = await _userService.GetUserById(id);
            try
            {
                await _userService.DeleteUser(id);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Account " + user.Username + " Deleted");
        }

        [HttpPut("UpdateUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserRequest updateUserRequest)
        {
            var newUser = updateUserRequest.AddUserRequest.ToEntity();
            try
            {
                await _userService.UpdateUser(updateUserRequest.Id, newUser);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok(new { message = "Account Updated", username = newUser.Username, email = newUser.Email, password = newUser.Password });
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _userService.VerifyCredentials(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return BadRequest("Invalid Credentials");
            }

            CreateTokenRequest createTokenRequest = new CreateTokenRequest
            {
                Id = user.Id.ToString(),
                Username = user.Username,
                Email = user.Email
            };

            var token = await JwtService.CreateToken(createTokenRequest);

            return Ok(new {token});
        }
    }
}
