using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> SearchBooksAsync(string? title, string? author, int? year);
        Task AddBookAsync(Book book, bool checkPublisherExistence = true);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
