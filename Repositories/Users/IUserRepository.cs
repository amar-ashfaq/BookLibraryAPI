using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Repositories.Users
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(int id);
        User CreateUser(User user);
        void DeleteUser(int id);
        void DeleteUsers();
    }
}
