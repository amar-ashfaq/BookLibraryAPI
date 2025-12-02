using BookLibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
