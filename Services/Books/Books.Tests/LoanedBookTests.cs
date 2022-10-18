using Books.Data.Models.LoanedBook;
using System;
using Xunit;

namespace Books.Tests
{
    public class LoanedBookTests
    {
        [Fact]
        public void TestAccruedFeePastOneDay()
        {
            //Test accrued fee past one day
            var feeAmount = 0.25;
            var loanedBook = new LoanedBook("test book", "this is a test book", DateTime.Now, DateTime.Now.AddDays(30), "abc", fee: feeAmount);
            loanedBook.PastDueOneDay();
            Assert.Equal(feeAmount, loanedBook.GetAccruedFee());
        }

        [Fact]
        public void TestAccruedFeePastDueForXDays()
        {
            //Test accrued fee past x days
            var feeAmount = 0.25;
            var pastDueDays = 4;
            var loanedBook = new LoanedBook("test book", "this is a test book", DateTime.Now, DateTime.Now.AddDays(30), "abc", fee: feeAmount);
            loanedBook.PastDueXDays(pastDueDays);
            var accruedTestFee = pastDueDays * feeAmount;
            Assert.Equal(accruedTestFee, loanedBook.GetAccruedFee());

        }

        [Fact]
        public void FeeNotSpecifiedTest()
        {
            var loanedBook = new LoanedBook("test book", "this is a test book", DateTime.Now, DateTime.Now.AddDays(30), "abc");
            loanedBook.PastDueOneDay();
            Assert.Equal(0, loanedBook.GetAccruedFee());
        }

        [Fact]
        public void FeeNotSpecifiedAndThenGivenTest()
        {
            var feeAmount = 0.25;
            var loanedBook = new LoanedBook("test book", "this is a test book", DateTime.Now, DateTime.Now.AddDays(30), "abc");
            loanedBook.PastDueOneDay();
            loanedBook.UpdateDailyFee(feeAmount);
            Assert.Equal(feeAmount, loanedBook.GetAccruedFee());
        }

        [Fact]
        public void TestReturn()
        {
            var loanedBook = new LoanedBook("test book", "this is a test book", DateTime.Now, DateTime.Now.AddDays(30), "abc");
            Assert.Equal(false, loanedBook.Returned);
            loanedBook.Return(DateTime.Now);
            Assert.Equal(true, loanedBook.Returned);
        }

        [Fact]
        public void TestUpdateDueDaysForBooks()
        {
            var loanedBook = new LoanedBook("test book", "this is a test book", DateTime.Now, DateTime.Now.AddDays(30), "abc");
            Assert.False(loanedBook.CheckIfInDue(DateTime.Now));
            Assert.True(loanedBook.CheckIfInDue(DateTime.Now.AddDays(40)));
        }
    }
}
