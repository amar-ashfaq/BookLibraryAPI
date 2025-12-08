using System.Security.Cryptography;
using System.Text;

namespace BookLibraryAPI.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly int keySize = 64;
        private readonly int iterations = 360000;
        private readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public string HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(64);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        public bool IsPasswordVerified(string enteredPassword, string storedHashPassword, byte[] storedSalt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(enteredPassword, storedSalt, iterations, hashAlgorithm, keySize);

            bool isVerified = CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(storedHashPassword));

            return isVerified;
        }
    }
}
