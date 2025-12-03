using BookLibraryAPI.Data;
using BookLibraryAPI.DTOs;
using BookLibraryAPI.Entities;
using BookLibraryAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly BookContext _context;

        public BookService(IBookRepository bookRepository, BookContext context)
        {
            this.bookRepository = bookRepository;
            _context = context;
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

            bookRepository.AddBook(book);
            await _context.SaveChangesAsync();

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

        public async Task<BookReadDto> UpdateBook(int id, BookUpdateDto bookDto)
        {
            ArgumentNullException.ThrowIfNull(bookDto);

            var book = bookRepository.GetBook(id);

            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.Author = bookDto.Author;
            book.Genre = bookDto.Genre;
            book.PublishedYear = bookDto.PublishedYear;
            book.IsAvailable = bookDto.IsAvailable;

            bookRepository.UpdateBook(id, book);

            await _context.SaveChangesAsync();
            
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

        public async Task DeleteBook(int id)
        {
            bookRepository.DeleteBook(id);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBooks()
        {
            bookRepository.DeleteBooks();
            await _context.SaveChangesAsync();
        }
    }
}
