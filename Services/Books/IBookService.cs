using BookLibraryAPI.DTOs.Books;

namespace BookLibraryAPI.Services.Books
{
    public interface IBookService
    {
        Task<List<BookReadDto>> GetBooks();
        Task<BookReadDto> GetBook(int id);
        Task<BookReadDto> AddBook(BookCreateDto book);
        Task UpdateBook(int id, BookUpdateDto book);
        Task DeleteBook(int id);
        Task DeleteBooks();
    }
}
