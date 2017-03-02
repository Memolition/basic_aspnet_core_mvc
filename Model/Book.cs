using MySQL.Data.EntityFrameworkCore.Extensions; 
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApplication {
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
        { }

        public DbSet<Books> Books { get; set; }
    }

    public static class BooksContextFactory
    {
        public static BooksContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BooksContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new BooksContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }

    public class Books
    {
        public Books()
        {
        }
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(70)]
        public string Author { get; set; }
    }
}