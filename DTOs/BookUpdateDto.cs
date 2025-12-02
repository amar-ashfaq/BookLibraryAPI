namespace BookLibraryAPI.DTOs
{
    public class BookUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublishedYear { get; set; }
        public bool IsAvailable { get; set; }
    }
}
