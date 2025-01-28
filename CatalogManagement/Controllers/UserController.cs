using Application.DTOs;
using Application.Requests;
using Application.Services;
using CatalogManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;

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
            return Ok("Account " + newUser.Username + " Updated");
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _userService.VerifyCredentials(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return BadRequest("Invalid Credentials");
            }
            return Ok(new { message = "Account " + user.Username + " Logged" });
        }
    }
}
