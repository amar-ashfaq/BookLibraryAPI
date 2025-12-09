using BookLibraryAPI.DTOs.Books;

namespace BookLibraryAPI.Services.Books
{
    public interface IBookService
    {
        List<BookReadDto> GetBooks();
        BookReadDto GetBook(int id);
        Task<BookReadDto> AddBook(BookCreateDto book);
        Task<BookReadDto> UpdateBook(int id, BookUpdateDto book);
        Task DeleteBook(int id);
        Task DeleteBooks();
    }
}
