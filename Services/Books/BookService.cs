using BookLibraryAPI.DTOs.Books;
using BookLibraryAPI.Entities;
using BookLibraryAPI.Repositories.Books;

namespace BookLibraryAPI.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<List<BookReadDto>> GetBooks()
        {
            var books = await bookRepository.GetBooks();

            var bookDtos = books
                .Select(book => new BookReadDto { 
                    Id = book.Id, 
                    Title = book.Title, 
                    Description = book.Description, 
                    Author = book.Author, 
                    Genre = book.Genre, 
                    PublishedYear = book.PublishedYear, 
                    IsAvailable = book.IsAvailable 
                }).ToList();

            return bookDtos;
        }

        public async Task<BookReadDto> GetBook(int id)
        {
            Book book = await bookRepository.GetBook(id);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {id} could not be found.");
            }

            return new BookReadDto()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Genre = book.Genre,
                PublishedYear = book.PublishedYear,
                IsAvailable = book.IsAvailable
            };
        }

        public async Task<BookReadDto> AddBook(BookCreateDto bookDto)
        {
            ArgumentNullException.ThrowIfNull(bookDto);

            var book = new Book()
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                Author = bookDto.Author,
                Genre = bookDto.Genre,
                PublishedYear = bookDto.PublishedYear,
                IsAvailable = bookDto.IsAvailable
            };

            await bookRepository.AddBook(book);

            return new BookReadDto()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Genre = book.Genre,
                PublishedYear = book.PublishedYear,
                IsAvailable = book.IsAvailable
            };
        }

        public async Task UpdateBook(int id, BookUpdateDto bookDto)
        {
            ArgumentNullException.ThrowIfNull(bookDto);

            var book = await bookRepository.GetBook(id);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {id} could not be found.");
            }

            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.Author = bookDto.Author;
            book.Genre = bookDto.Genre;
            book.PublishedYear = bookDto.PublishedYear;
            book.IsAvailable = bookDto.IsAvailable;

            await bookRepository.UpdateBook();
        }

        public async Task DeleteBook(int id)
        {
            Book book = await bookRepository.GetBook(id);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {id} could not be found.");
            }

            await bookRepository.DeleteBook(book);
        }

        public async Task DeleteBooks()
        {
            await bookRepository.DeleteBooks();
        }
    }
}
