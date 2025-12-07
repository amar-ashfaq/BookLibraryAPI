using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Services
{
    public interface ITokenService
    {
        public string GenerateJwtToken(User user);
    }
}
