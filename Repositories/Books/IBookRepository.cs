using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Repositories.Books
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        Book AddBook(Book book);
        Book UpdateBook(int id, Book book);
        void DeleteBook(int id);
        void DeleteBooks();
    }
}
