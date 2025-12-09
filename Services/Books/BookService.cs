using BookLibraryAPI.DTOs.Books;
using BookLibraryAPI.Entities;
using BookLibraryAPI.Repositories.Books;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public List<BookReadDto> GetBooks()
        {
            var books = bookRepository.GetBooks();

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

        public BookReadDto GetBook(int id)
        {
            Book book = bookRepository.GetBook(id);

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

        public BookReadDto AddBook(BookCreateDto bookDto)
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

            bookRepository.AddBook(book);

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

        public BookReadDto UpdateBook(int id, BookUpdateDto bookDto)
        {
            ArgumentNullException.ThrowIfNull(bookDto);

            var book = bookRepository.GetBook(id);

            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.Author = bookDto.Author;
            book.Genre = bookDto.Genre;
            book.PublishedYear = bookDto.PublishedYear;
            book.IsAvailable = bookDto.IsAvailable;

            bookRepository.UpdateBook();
            
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

        public void DeleteBook(int id)
        {
            bookRepository.DeleteBook(id);
        }

        public void DeleteBooks()
        {
            bookRepository.DeleteBooks();
        }
    }
}
