using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Repositories.Books
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task AddBook(Book book);
        Task UpdateBook();
        Task DeleteBook(Book book);
        Task DeleteBooks();
    }
}
