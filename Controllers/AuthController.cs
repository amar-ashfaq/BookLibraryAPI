using BookLibraryAPI.DTOs;
using BookLibraryAPI.Repositories;
using BookLibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public AuthController(ITokenService tokenService, IUserRepository userRepository, IPasswordService passwordService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequestDto loginRequest)
        {
            var user = _userRepository.GetUsers().FirstOrDefault(x => x.Username == loginRequest.Username);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            var salt = Convert.FromHexString(user.PasswordSalt);

            bool isPasswordVerified = _passwordService.IsPasswordVerified(loginRequest.Password, user.PasswordHash, salt);

            if (!isPasswordVerified)
            {
                return Unauthorized("Invalid username or password");
            }

            var token = _tokenService.GenerateJwtToken(user);

            return Ok(new { token });
        }
    }
}
