using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().ToTable("books");
            modelBuilder.Entity<Publisher>().ToTable("publishers");
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Loan>().ToTable("loans");
            modelBuilder.Entity<User>().ToTable("users").HasIndex(e => e.Email).IsUnique();
        }
    }
}
