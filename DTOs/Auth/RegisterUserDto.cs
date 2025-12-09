using System.ComponentModel.DataAnnotations;

namespace BookLibraryAPI.DTOs.Auth
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
