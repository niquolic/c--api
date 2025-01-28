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
