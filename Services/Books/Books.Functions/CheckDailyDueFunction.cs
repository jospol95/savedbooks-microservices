using System;
using System.Linq;
using System.Threading.Tasks;
using Books.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Books.Functions
{
    //Azure function to check (ideally daily) if a Book is in Due.
    public class CheckDailyDueFunction
    {
        private readonly ILoanedBookService _bookService;
        public CheckDailyDueFunction(ILoanedBookService bookService)
        {
            this._bookService = bookService;
        }

        [FunctionName("CheckDailyDueFunction")]
        public async Task Run([TimerTrigger("0 00 7 * * 1-5")]TimerInfo myTimer, ILogger log)
        {
            var currentDate = DateTime.Now;
            log.LogInformation($"CheckDailyDueFunction Timer trigger function executed at: {currentDate}");
            var books = await _bookService.Get();
            var booksInDueInTheNext3Days = 
                books.Where((b) => IsDateBetweenPeriod(b.DateTimeToReturn, currentDate.AddDays(3)));
            log.LogInformation($"Found {booksInDueInTheNext3Days.Count()} Books");

            var booksAlreadyInDue = books.Where(b => b.CheckIfInDue(currentDate));
            booksAlreadyInDue.ToList().ForEach((b) => b.UpdatePastDueFromDate(currentDate));
        }

        public bool IsDateBetweenPeriod(DateTime datimeToCompare, DateTime DaysFromNow)
        {
            var currentDay = DateTime.Now.DayOfYear;
            var dayLimit = DaysFromNow.DayOfYear;
            var dayToCompare = datimeToCompare.DayOfYear;

            if(dayToCompare >= currentDay && dayToCompare <= dayLimit)
            {
                return true;
            }
            return false;

        }
    }
}
