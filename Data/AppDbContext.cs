using BookLibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
