using BookLibraryAPI.DTOs;

namespace BookLibraryAPI.Repositories
{
    public interface IBookRepository
    {
        List<BookReadDto> GetBooks();
        BookReadDto GetBook(int id);
        BookCreateDto AddBook(BookReadDto book);
        BookUpdateDto UpdateBook(BookReadDto book);
        void DeleteBook(int id);
        void DeleteBooks();
    }
}
