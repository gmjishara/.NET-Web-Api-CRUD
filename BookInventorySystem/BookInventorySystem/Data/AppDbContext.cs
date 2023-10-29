using BookInventorySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookInventorySystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
       
    }
}
