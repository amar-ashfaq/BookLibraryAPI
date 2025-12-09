using BookLibraryAPI.DTOs.Auth;
using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Services.Users
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUser(int id);
        User RegisterUser(RegisterUserDto user);
        void DeleteUser(int id);
        void DeleteUsers();
    }
}
