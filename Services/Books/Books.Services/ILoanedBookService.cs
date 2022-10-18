using Books.Data.Models.LoanedBook;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Services
{
    public interface ILoanedBookService
    {
        Task<List<LoanedBook>> GetAllForUser(string userId);
        Task<List<LoanedBook>> Get();
        Task<LoanedBook> Get(string bookId);
        Task<LoanedBook> Create(LoanedBook book);

        Task UpdateDueDaysForBooks(DateTime dateTimeToCompare);
    }
}
