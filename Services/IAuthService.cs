using BookLibraryAPI.DTOs;
using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Services
{
    public interface IAuthService
    {
        User RegisterUser(RegisterUserDto registerUserDto);
        string LoginUser(LoginRequestDto loginRequestDto);
    }
}
