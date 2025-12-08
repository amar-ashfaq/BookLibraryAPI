using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(int id);
        User CreateUser(User user);
    }
}
