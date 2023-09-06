using Microsoft.EntityFrameworkCore;
using MVC_Ornek2.Configurations;
using MVC_Ornek2.Models;

namespace MVC_Ornek2.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent api -> kodların, veritabanı tablolarını dönüştürülürkenki biçimlendirme işlemleri.

            //modelBuilder.Entity<Operation>().Ignore("Id");
            //modelBuilder.Entity<Operation>().HasKey("StudentId", "BookId");

            // üstteki kısımları Configurations klasöründen çekeceğim.

            modelBuilder.ApplyConfiguration(new OperationConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Author> Authors => Set <Author>();
        public DbSet<BookType> BookTypes => Set<BookType>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Operation> Operations => Set<Operation>();
    }
}
