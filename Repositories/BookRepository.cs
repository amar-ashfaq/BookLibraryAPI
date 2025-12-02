using BookLibraryAPI.DTOs;

namespace BookLibraryAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        public BookCreateDto AddBook(BookReadDto book)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteBooks()
        {
            throw new NotImplementedException();
        }

        public BookReadDto GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookReadDto> GetBooks()
        {
            throw new NotImplementedException();
        }

        public BookUpdateDto UpdateBook(BookReadDto book)
        {
            throw new NotImplementedException();
        }
    }
}
