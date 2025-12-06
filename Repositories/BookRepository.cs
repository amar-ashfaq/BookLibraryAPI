using BookLibraryAPI.Data;
using BookLibraryAPI.Entities;

namespace BookLibraryAPI.Repositories
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

        public Book AddBook(Book book)
        {
            // can remove this check once service layer is done
            if (book == null)
            {
                throw new ArgumentNullException("Book input is malformed or invalid");
            }

            _context.Books.Add(book);

            return book;
        }

        public Book UpdateBook(int id, Book book)
        {
            var bookToUpdate = _context.Books.FirstOrDefault(x => x.Id == id);

            if (bookToUpdate == null)
            {
                throw new KeyNotFoundException($"Book with id {id} could not be found.");
            }

            // can remove this check once service layer is done
            if (book == null)
            {
                throw new ArgumentNullException("Book input is malformed or invalid");
            }

            bookToUpdate.Title = book.Title;
            bookToUpdate.Description = book.Description;
            bookToUpdate.Author = book.Author;
            bookToUpdate.Genre = book.Genre;
            bookToUpdate.PublishedYear = book.PublishedYear;
            bookToUpdate.IsAvailable = book.IsAvailable;

            return bookToUpdate;
        }                                                                 
        public void DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
                                                                   
            if (book == null)
            {
                throw new KeyNotFoundException($"Book of id {id} could not be found.");
            }

            _context.Books.Remove(book);
        }

        public void DeleteBooks()
        {
            _context.Books.RemoveRange(_context.Books);                                                
        }
    }
}
