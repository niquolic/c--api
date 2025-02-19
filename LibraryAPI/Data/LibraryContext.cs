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

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action" },
                new Category { Id = 2, Name = "Romantique" },
                new Category { Id = 3, Name = "Thriller" },
                new Category { Id = 4, Name = "Biographie" },
                new Category { Id = 5, Name = "Histoire" }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "John Doe", ContactEmail = "johndoe@gmail.com", FoundedYear = 2000 },
                new Publisher { Id = 2, Name = "Thierry Henry corp", ContactEmail = "thenry@gmail.com", FoundedYear = 2005 },
                new Publisher { Id = 3, Name = "Zinédine Zidane le z la vraie librairie", ContactEmail = "zzidane@gmail.com", FoundedYear = 2010 },
                new Publisher { Id = 4, Name = "Colonel Reyel le flopesque libraire", ContactEmail = "creyel@gmail.com", FoundedYear = 2015 },
                new Publisher { Id = 5, Name = "René la taupe le goat du livre", ContactEmail = "renetaupe@gmail.com", FoundedYear = 2020 }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Client 1", Email = "client1@gmail.com", Role = "Lecteur" },
                new User { Id = 2, Name = "Client 2", Email = "client2@gmail.com", Role = "Lecteur" },
                new User { Id = 3, Name = "Client 3", Email = "client3@gmail.com", Role = "Lecteur" },
                new User { Id = 4, Name = "Client 4", Email = "client4@gmail.com", Role = "Lecteur" },
                new User { Id = 5, Name = "Administrateur 1", Email = "admin@gmail.com", Role = "Administrateur" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Livre1", Author = "Robert C. Martin", PublishedYear = 2008, Isbn = "9780132350884", PublisherId = 1, CategoryId = 1 },
                new Book { Id = 2, Title = "Livre 2", Author = "Andrew Hunt", PublishedYear = 2020, Isbn = "9780201616224", PublisherId = 2, CategoryId = 2 },
                new Book { Id = 3, Title = "Livre 3", Author = "Erich Gamma", PublishedYear = 2019, Isbn = "9780201633610", PublisherId = 3, CategoryId = 3 },
                new Book { Id = 4, Title = "Livre 4", Author = "Martin Fowler", PublishedYear = 2018, Isbn = "9780201485677", PublisherId = 4, CategoryId = 4 },
                new Book { Id = 5, Title = "Livre 5", Author = "Steve McConnell", PublishedYear = 2022, Isbn = "9780735619678", PublisherId = 5, CategoryId = 5 },
                new Book { Id = 6, Title = "Livre 6", Author = "Steve McConnell 2", PublishedYear = 2022, Isbn = "9780735619679", PublisherId = 1, CategoryId = 1 },
                new Book { Id = 7, Title = "Livre 7", Author = "Steve McConnell 3", PublishedYear = 2022, Isbn = "9780735619680", PublisherId = 2, CategoryId = 2 },
                new Book { Id = 8, Title = "Livre 8", Author = "Steve McConnell 4", PublishedYear = 2022, Isbn = "9780735619681", PublisherId = 3, CategoryId = 3 },
                new Book { Id = 9, Title = "Livre 9", Author = "Steve McConnell 5", PublishedYear = 2022, Isbn = "9780735619682", PublisherId = 4, CategoryId = 4 },
                new Book { Id = 10, Title = "Livre 10", Author = "Steve McConnell 6", PublishedYear = 2022, Isbn = "9780735619683", PublisherId = 5, CategoryId = 5 }
            );

            modelBuilder.Entity<Loan>().HasData(
                new Loan { Id = 1, BookId = 1, BorrowerName = "Client 1", BorrowDate = new System.DateTime(2022, 1, 1), ReturnDate = new System.DateTime(2022, 1, 15) },
                new Loan { Id = 2, BookId = 2, BorrowerName = "Client 2", BorrowDate = new System.DateTime(2022, 1, 1), ReturnDate = new System.DateTime(2022, 1, 15) },
                new Loan { Id = 3, BookId = 3, BorrowerName = "Client 2", BorrowDate = new System.DateTime(2022, 1, 1), ReturnDate = new System.DateTime(2022, 1, 15) },
                new Loan { Id = 4, BookId = 4, BorrowerName = "Client 3", BorrowDate = new System.DateTime(2022, 1, 1), ReturnDate = new System.DateTime(2022, 1, 15) },
                new Loan { Id = 5, BookId = 5, BorrowerName = "Client 4", BorrowDate = new System.DateTime(2022, 1, 1), ReturnDate = new System.DateTime(2022, 1, 15) }
            );
        }
    }
}
