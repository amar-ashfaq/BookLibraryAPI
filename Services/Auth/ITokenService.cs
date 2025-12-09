using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Services.Auth
{
    public interface ITokenService
    {
        public string GenerateJwtToken(User user);
    }
}
