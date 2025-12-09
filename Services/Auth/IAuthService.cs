using BookLibraryAPI.DTOs.Auth;
using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Services.Auth
{
    public interface IAuthService
    {
        User RegisterUser(RegisterUserDto registerUserDto);
        string LoginUser(LoginRequestDto loginRequestDto);
    }
}
