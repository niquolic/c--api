using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class CategoryService
    {
        private readonly LibraryContext _context;

        public CategoryService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Category>> GetCategoriesAsync()
        {
            return _context.Categories.AsQueryable();
        }

        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                throw new Exception("Category not found");

            var hasBooks = await _context.Books.AnyAsync(b => b.CategoryId == id);
            if (hasBooks)
                throw new Exception("Category has books associated");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
