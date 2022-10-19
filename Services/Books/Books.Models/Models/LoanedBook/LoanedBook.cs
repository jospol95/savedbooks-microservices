using Books.Data.Models;
using Books.Data.Models.Libraries;
using Libraries.Data.Models;
using System;

namespace Books.Data.Models.LoanedBook
{
    public partial class LoanedBook : Book
    {
        public DateTime DateTimeRequested { get; set; }
        public DateTime DateTimeToReturn { get; set; }
        public double? DailyFee { get; set; }
        public bool? Returned { get; set; }
        public DateTime? DateTimeReturned { get; set; }
        private int DueDays { get; set; }
        public Library Library { get; set; }

        public LoanedBook()
        {

        }

        public LoanedBook(string title, string description, DateTime dateRequested, DateTime dateToReturn, string libraryId, double? fee = 0)
        {
            Title = title;
            Description = description;
            DateTimeToReturn = dateToReturn;
            DateTimeRequested = dateRequested;
            DailyFee = fee;
            DueDays = 0;
            Returned = false;
        }
      
    }
}
