using Books.Api.Controllers;
using Books.Data.Models.LoanedBook;
using Books.Services;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Books.Tests
{
    public class BooksControllersTests
    {
        [Fact]
        public async Task Test()
        {
            //Arrange
            var count = 5;
            var fakeBooks = A.CollectionOfDummy<LoanedBook>(count).AsEnumerable();
            var booksService = A.Fake<ILoanedBookService>();
            A.CallTo(() => booksService.Get());
            var booksController = new BooksController(booksService);

            //Act
            var actionResult = await booksController.GetAll();

            //Assert 
            var result = actionResult.Result as OkObjectResult;
            var returnBooks = result.Value as IEnumerable<LoanedBook>;

        }

        [Fact]
        public async Task TestSingleBookGetter()
        {
            //Arrange
            var fakeBook = A.Fake<LoanedBook>();
            fakeBook.Id = "abcdefg";
            var booksService = A.Fake<ILoanedBookService>();
            A.CallTo(() => booksService.Get("abcdefg")).Returns(fakeBook);
            var booksController = new BooksController(booksService);

            //Act
            var actionResult = await booksController.Get("abcdefg");

            //Assert 
            var result = actionResult.Result as OkObjectResult;
            var bookResult = result.Value as LoanedBook;
            Assert.Equal(fakeBook.Id, bookResult.Id);

        }

    }
}
