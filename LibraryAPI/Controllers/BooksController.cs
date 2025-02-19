using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Get a list of books
        /// </summary>
        /// <param name="author">The author of the book</param>
        /// <param name="year">The year the book was published</param>
        /// <param name="categoryId">The category ID of the book</param>
        /// <param name="publisherId">The publisher ID of the book</param>
        /// <param name="sortBy">The field to sort by</param>
        /// <param name="isDescending">Whether to sort in descending order</param>
        /// <returns>A list of books</returns>
        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] string? author, [FromQuery] int? year, [FromQuery] int? categoryId, [FromQuery] int? publisherId, [FromQuery] string? sortBy, [FromQuery] bool isDescending)
        {
            var books = await _bookService.GetBooksAsync(author, year, categoryId, publisherId, sortBy, isDescending);
            return Ok(books);
        }

        /// <summary>
        /// Get a book by its ID
        /// </summary>
        /// <param name="id">The ID of the book</param>
        /// <returns>The book</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        /// <summary>
        /// Add a book
        /// </summary>
        /// <param name="book">The book to add</param>
        /// <returns>The added book</returns>
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            try
            {
                await _bookService.AddBookAsync(book);
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="id">The ID of the book</param>
        /// <param name="book">The updated book</param>
        /// <returns>No content</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.Id)
                return BadRequest("ID mismatch");

            try
            {
                await _bookService.UpdateBookAsync(book);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="id">The ID of the book</param>
        /// <returns>No content</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
