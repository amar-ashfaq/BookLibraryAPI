using System.ComponentModel.DataAnnotations;

namespace BookLibraryAPI.DTOs
{
    public class BookUpdateDto
    {
        [Required(ErrorMessage = "Book title is required")]
        [StringLength(50, ErrorMessage = "Book title cannot be longer than 50 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Book description is required")]
        [StringLength(500, ErrorMessage = "Book description cannot be longer than 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Book author is required")]
        [StringLength(50, ErrorMessage = "Book author cannot be longer than 50 characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Book genre is required")]
        [StringLength(50, ErrorMessage = "Book genre cannot be longer than 50 characters")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Published year is required")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Year must be a 4-digit number.")]
        [YearRange(1900)]
        public int PublishedYear { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
