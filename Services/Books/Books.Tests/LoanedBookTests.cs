using Books.Data.Models.LoanedBook;
using System;
using Xunit;

namespace Books.Tests
{
    public class LoanedBookTests
    {
        public LoanedBook CreateBorrowedBookWithDaysToBorrow(int daysToBorrow, double fee)
        {
            LoanedBook loanedBook = new LoanedBook();
            loanedBook.DateTimeBorrowed = DateTime.Now;
            loanedBook.DateTimeToReturn = DateTime.Now.AddDays(daysToBorrow);
            loanedBook.DailyFee = fee;
            return loanedBook;
        }

        [Fact]
        public void TestBookPastDueSameYear()
        {
            //Compare January 1st against January 12th.
            //If you return the book on January 1st, no fees.
            //If you return the book on January 12th, 11 days have passed that you accrued fee.

            //Arrange
            var pastDueDays = 11;
            var testFee = 0.25;
            var firstDate = new DateTime(DateTime.Now.Year, 1, 1);
            var pastDueDate = firstDate.AddDays(pastDueDays);
            var calc = pastDueDays * testFee;

            LoanedBook borrowedBook = new LoanedBook();
            borrowedBook.DateTimeToReturn = firstDate;
            borrowedBook.DailyFee = testFee;

            //Act
            var dueFee = borrowedBook.GetAccumulatedFee(pastDueDate);

            //Assert
            Assert.Equal(calc, dueFee);
        }

        [Fact]
        public void TestBookPastDueOneYearDifference()
        {
            //Arrange
            var pastDueDays = 364;
            var firstDate = new DateTime(DateTime.Now.Year, 1, 1);
            var pastDueDate = firstDate.AddDays(pastDueDays);
            var testFee = 0.25;
            var calc = pastDueDays * testFee;

            LoanedBook borrowedBook = new LoanedBook();
            borrowedBook.DateTimeToReturn = firstDate;
            borrowedBook.DailyFee = testFee;

            //Act
            var dueFee = borrowedBook.GetAccumulatedFee(pastDueDate);

            //Assert
            Assert.Equal(calc, dueFee);
        }

        [Fact]
        public void TestBookNotPastDue()
        {
            //Arrange
            var todaysDate = DateTime.Now;
            var dueDate = todaysDate.AddDays(12);

            LoanedBook borrowedBook = new LoanedBook();
            borrowedBook.DateTimeToReturn = dueDate;
            borrowedBook.DailyFee = 0.25;

            //Act
            var dueFee = borrowedBook.GetAccumulatedFee(todaysDate);

            //Assert
            Assert.Equal(0, dueFee);
        }


        [Fact]
        public void TestAccumulatedFeePastDueWithNotGivenFee()
        {
            //Arrange
            LoanedBook borrowedBook = new LoanedBook();
            borrowedBook.DateTimeToReturn = DateTime.Now;
            var pastDueDate = DateTime.Now.AddDays(10);

            //Act
            var dueFee = borrowedBook.GetAccumulatedFee(pastDueDate);

            //Assert
            Assert.Equal(0, dueFee);
        }

        //[Fact]
        //public void TestCheckIfBookInDue()
        //{
        //    var borrowedBook = CreateBorrowedBookWithDaysToBorrow(30, 0.25);
        //    Assert.False(borrowedBook.InDue());

        //    borrowedBook.D

        //}

        //[Fact]
        //public void TestAccruedFeePastOneDay()
        //{
        //    //Test accrued fee past one day
        //    var feeAmount = 0.25;
        //    var loanedBook = new LoanedBook("test book", "this is a test book", DateTime.Now, DateTime.Now.AddDays(30), "abc", fee: feeAmount);
        //    loanedBook.PastDueOneDay();
        //    Assert.Equal(feeAmount, loanedBook.GetAccruedFee());
        //}

        //[Fact]
        //public void TestAccumulatedFeeOneDay()
        //{
        //    //Test accrued fee past x days
        //    var feeAmount = 0.25;
        //    var pastDueDays = 4;
        //    var loanedBook = new LoanedBook("test book", "this is a test book", DateTime.Now, DateTime.Now.AddDays(30), "abc", fee: feeAmount);
        //    loanedBook.PastDueXDays(pastDueDays);
        //    var accruedTestFee = pastDueDays * feeAmount;
        //    Assert.Equal(accruedTestFee, loanedBook.GetAccruedFee());

        //}

        //[Fact]
        //public void FeeNotSpecifiedTest()
        //{
        //    var loanedBook = new LoanedBook("test book", "this is a test book", DateTime.Now, DateTime.Now.AddDays(30), "abc");
        //    loanedBook.PastDueOneDay();
        //    Assert.Equal(0, loanedBook.GetAccruedFee());
        //}

        //[Fact]
        //public void FeeNotSpecifiedAndThenGivenTest()
        //{
        //    var feeAmount = 0.25;
        //    var loanedBook = new LoanedBook("test book", "this is a test book", DateTime.Now, DateTime.Now.AddDays(30), "abc");
        //    loanedBook.PastDueOneDay();
        //    loanedBook.UpdateDailyFee(feeAmount);
        //    Assert.Equal(feeAmount, loanedBook.GetAccruedFee());
        //}

        //[Fact]
        //public void TestReturn()
        //{
        //    var loanedBook = new LoanedBook("test book", "this is a test book", DateTime.Now, DateTime.Now.AddDays(30), "abc");
        //    Assert.Equal(false, loanedBook.Returned);
        //    loanedBook.Return(DateTime.Now);
        //    Assert.Equal(true, loanedBook.Returned);
        //}

        //[Fact]
        //public void TestUpdateDueDaysForBooks()
        //{
        //    var loanedBook = new LoanedBook("test book", "this is a test book", DateTime.Now, DateTime.Now.AddDays(30), "abc");
        //    Assert.False(loanedBook.CheckIfInDue(DateTime.Now));
        //    Assert.True(loanedBook.CheckIfInDue(DateTime.Now.AddDays(40)));
        //}
    }
}
