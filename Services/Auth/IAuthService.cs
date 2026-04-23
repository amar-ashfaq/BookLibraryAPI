using BookLibraryAPI.DTOs.Auth;

namespace BookLibraryAPI.Services.Auth
{
    public interface IAuthService
    {
        string LoginUser(LoginRequestDto loginRequestDto);
    }
}
