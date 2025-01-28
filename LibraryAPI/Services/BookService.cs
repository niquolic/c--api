using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class BookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Book>> GetBooksAsync(string author = null, int? year = null, int? categoryId = null, int? publisherId = null, string sortBy = "Title", bool isDescending = false)
        {
            var query = _context.Books.Include(b => b.CategoryId).Include(b => b.PublisherId).AsQueryable();

            if (!string.IsNullOrEmpty(author))
                query = query.Where(b => b.Author.Contains(author));

            if (year.HasValue)
                query = query.Where(b => b.PublishedYear == year.Value);

            if (categoryId.HasValue)
                query = query.Where(b => b.CategoryId == categoryId.Value);

            if (publisherId.HasValue)
                query = query.Where(b => b.PublisherId == publisherId.Value);

            query = isDescending ? query.OrderByDescending(b => EF.Property<object>(b, sortBy)) : query.OrderBy(b => EF.Property<object>(b, sortBy));

            return query;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.Include(b => b.CategoryId).Include(b => b.PublisherId).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await GetBookByIdAsync(id);
            if (book == null)
                throw new Exception("Book not found");

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
