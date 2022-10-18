using Books.Data.Models.LoanedBook;
using Books.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Infrastructure.Services
{
    public class LoanedBookService : ILoanedBookService
    {
        public Task<LoanedBook> Create(LoanedBook book)
        {
            throw new NotImplementedException();
        }

        public Task<LoanedBook> Get(string bookId)
        {
            throw new NotImplementedException();
        }

        public Task<List<LoanedBook>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<List<LoanedBook>> GetAllForUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDueDaysForBooks(DateTime dateTimeToCompare)
        {
            throw new NotImplementedException();
        }
    }
}
