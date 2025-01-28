using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Services
{
    public class LoanService
    {
        private readonly LibraryContext _context;

        public LoanService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Loan>> GetLoansAsync(string borrowerName = null, int? bookId = null, DateTime? borrowDate = null)
        {
            var query = _context.Loans.AsQueryable();

            if (!string.IsNullOrEmpty(borrowerName))
                query = query.Where(l => l.BorrowerName.Contains(borrowerName));

            if (bookId.HasValue)
                query = query.Where(l => l.BookId == bookId.Value);

            if (borrowDate.HasValue)
                query = query.Where(l => l.BorrowDate.Date == borrowDate.Value.Date);

            return query;
        }

        public async Task AddLoanAsync(Loan loan)
        {
            loan.BorrowDate = loan.BorrowDate == default ? DateTime.Now : loan.BorrowDate;
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLoanAsync(int id, DateTime returnDate)
        {
            var loan = await _context.Loans.FirstOrDefaultAsync(l => l.Id == id);
            if (loan == null)
                throw new Exception("Loan not found");

            loan.ReturnDate = returnDate;
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }
    }
}
