using BookLibraryAPI.DTOs;
using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Services
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
