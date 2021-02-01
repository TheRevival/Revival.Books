using Microsoft.EntityFrameworkCore;
using Revival.Books.Data.Models;

namespace Revival.Books.Data
{
    public class RevivalBooksDbContext : DbContext
    {
        public RevivalBooksDbContext(DbContextOptions options)
            : base(options) { }
            
        public virtual DbSet<Book> Books { get; set; }    
        public virtual DbSet<Author> Authors { get; set; }    
    }
}
