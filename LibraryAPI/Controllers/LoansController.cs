using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly LoanService _loanService;

        public LoanController(LoanService loanService)
        {
            _loanService = loanService;
        }

        /// <summary>
        /// Add a loan
        /// </summary>
        /// <param name="loan">The loan to add</param>
        /// <returns>The added loan</returns>
        [HttpPost]
        public async Task<ActionResult<Loan>> AddLoan([FromBody] Loan loan)
        {
            try
            {
                await _loanService.AddLoanAsync(loan);
                return CreatedAtAction(nameof(GetLoans), new { id = loan.Id }, loan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while saving a loan : {ex.Message}");
            }
        }

        /// <summary>
        /// Update a loan with the return date
        /// </summary>
        /// <param name="id">The ID of the loan</param>
        /// <param name="returnDate">The return date</param>
        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnLoan(int id, [FromBody] DateTime returnDate)
        {
            try
            {
                await _loanService.UpdateLoanAsync(id, returnDate);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur lors de l'enregistrement de la date de retour : {ex.Message}");
            }
        }

        /// <summary>
        /// Get a list of loans
        /// </summary>
        /// <param name="borrowerName">The name of the borrower</param>
        /// <param name="bookId">The ID of the book</param>
        /// <param name="borrowDate">The borrow date</param>
        /// <returns>A list of loans</returns>
        [HttpGet]
        public async Task<ActionResult<IQueryable<Loan>>> GetLoans(
            [FromQuery] string borrowerName = null,
            [FromQuery] int? bookId = null,
            [FromQuery] DateTime? borrowDate = null)
        {
            try
            {
                var loans = await _loanService.GetLoansAsync(borrowerName, bookId, borrowDate);
                return Ok(loans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error while fetching loans : {ex.Message}");
            }
        }
    }
}
