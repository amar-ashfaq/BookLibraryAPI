using BookLibraryAPI.DTOs;
using BookLibraryAPI.Entities;
using BookLibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register(RegisterUserDto registerUserDto)
        {
            var user = _authService.RegisterUser(registerUserDto);
            return CreatedAtAction(nameof(GetProfile), new { user.Id }, user);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequestDto loginRequest)
        {
            string token = _authService.LoginUser(loginRequest);
            return Ok(new { token });
        }

        [Authorize]
        [HttpGet("authtest")]
        public IActionResult AuthTest()
        {
            return Ok(
                new
                {
                    User = User.Identity?.Name,
                    Claims = User.Claims.Select(c => new {c.Type, c.Value})
                }
            );
        }

        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usernameFromToken = User.Identity?.Name;

            Console.WriteLine($"The user id is {userIdClaim} and the username is {usernameFromToken}");

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Unauthorized("User id claim is missing");
            }

            if (!int.TryParse(userIdClaim.ToString(), out int userId))
            {
                return Unauthorized("User id claim is invalid");
            }

            var userProfile = _userService.GetUser(userId);

            if (userProfile == null)
            {
                return NotFound("User profile does not exist");
            }

            return Ok(
                new
                {
                    usernameFromToken,
                    userProfile.Id,
                    userProfile.Name,
                    userProfile.Username,
                    userProfile.Role
                }
            );
        }

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _userService.GetUser(id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) 
        {
            _userService.DeleteUser(id);
            return NoContent();  
        }

        [HttpDelete]
        public IActionResult DeleteUsers()
        {
            _userService.DeleteUsers();
            return NoContent();
        }
    }
}
