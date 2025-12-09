using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Repositories.Books
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        void AddBook(Book book);
        void UpdateBook();
        void DeleteBook(int id);
        void DeleteBooks();
    }
}
