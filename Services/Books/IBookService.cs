using BookLibraryAPI.DTOs.Books;

namespace BookLibraryAPI.Services.Books
{
    public interface IBookService
    {
        List<BookReadDto> GetBooks();
        BookReadDto GetBook(int id);
        BookReadDto AddBook(BookCreateDto book);
        BookReadDto UpdateBook(int id, BookUpdateDto book);
        void DeleteBook(int id);
        void DeleteBooks();
    }
}
