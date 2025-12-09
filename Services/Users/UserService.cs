using BookLibraryAPI.DTOs.Auth;
using BookLibraryAPI.Entities;
using BookLibraryAPI.Repositories.Users;
using BookLibraryAPI.Services.Auth;

namespace BookLibraryAPI.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public UserService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public List<User> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return users;
        }

        public User GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            return user;
        }

        public User RegisterUser(RegisterUserDto userDto)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }

            var user = new User
            {
                Name = userDto.Name,
                Username = userDto.Username,
                PasswordHash = _passwordService.HashPassword(userDto.Password, out var salt),
                PasswordSalt = Convert.ToHexString(salt),
                Role = "user"
            };

            _userRepository.CreateUser(user);

            return user;
        }
        
        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public void DeleteUsers()
        {
            _userRepository.DeleteUsers();
        }
    }
}
