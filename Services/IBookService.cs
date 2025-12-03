using BookLibraryAPI.DTOs;

namespace BookLibraryAPI.Services
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
