using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class PublisherService
    {
        private readonly LibraryContext _context;

        public PublisherService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Publisher>> GetPublishersAsync()
        {
            return _context.Publishers.AsQueryable();
        }

        public async Task AddPublisherAsync(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePublisherAsync(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
                throw new Exception("Publisher not found");

            var hasBooks = await _context.Books.AnyAsync(b => b.PublisherId == id);
            if (hasBooks)
                throw new Exception("Publisher has books associated");

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
        }
    }
}
