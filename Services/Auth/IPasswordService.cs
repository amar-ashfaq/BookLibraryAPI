namespace BookLibraryAPI.Services.Auth
{
    public interface IPasswordService
    {
        string HashPassword(string password, out byte[] salt);
        bool IsPasswordVerified(string enteredPassword, string storedHashPassword, byte[] storedSalt);
    }
}
