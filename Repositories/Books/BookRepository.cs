using BookLibraryAPI.Data;
using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBook(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {id} could not be found.");
            }

            return book;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook()
        {
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = GetBook(id);

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void DeleteBooks()
        {
            _context.Books.RemoveRange(_context.Books);
            _context.SaveChanges();
        }
    }
}
