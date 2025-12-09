using BookLibraryAPI.Data;
using BookLibraryAPI.Entities;
using BookLibraryAPI.Services.Auth;

namespace BookLibraryAPI.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IPasswordService _passwordService;

        public UserRepository(AppDbContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }
        public List<User> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} could not be found");
            }

            return user;
        }

        public User GetUserByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new KeyNotFoundException($"Username {username} could not be found");
            }

            return user;
        }

        public User CreateUser(User user)
        {
            var hash = _passwordService.HashPassword(user.PasswordHash, out var salt);

            user.PasswordHash = hash;
            user.PasswordSalt = Convert.ToHexString(salt);

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void DeleteUser(int id) 
        { 
            var user = GetUser(id);

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void DeleteUsers()
        {
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();
        }
    }
}
