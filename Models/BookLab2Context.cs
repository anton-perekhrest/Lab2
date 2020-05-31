using Microsoft.EntityFrameworkCore;


namespace BookLab2.Models
{
    public class BookLab2Context: DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public BookLab2Context(DbContextOptions<BookLab2Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
