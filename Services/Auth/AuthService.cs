using BookLibraryAPI.DTOs.Auth;
using BookLibraryAPI.Entities;
using BookLibraryAPI.Repositories.Users;

namespace BookLibraryAPI.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordService = passwordService;
        }

        public User RegisterUser(RegisterUserDto registerUserDto)
        {
            ArgumentNullException.ThrowIfNull(registerUserDto);

            var user = new User
            {
                Name = registerUserDto.Name,
                Username = registerUserDto.Username,
                PasswordHash = registerUserDto.Password,
                Role = "user"
            };

            return _userRepository.CreateUser(user);
        }

        public string LoginUser(LoginRequestDto loginRequestDto)
        {
            var user = _userRepository.GetUsers().FirstOrDefault(x => x.Username == loginRequestDto.Username);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            var salt = Convert.FromHexString(user.PasswordSalt);

            bool isPasswordVerified = _passwordService.IsPasswordVerified(loginRequestDto.Password, user.PasswordHash, salt);

            if (!isPasswordVerified)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            var token = _tokenService.GenerateJwtToken(user);
            return token;
        }
    }
}
