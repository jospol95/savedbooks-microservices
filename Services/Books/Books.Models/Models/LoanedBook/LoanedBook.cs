using Books.Data.Models;
using System;

namespace Books.Data.Models.LoanedBook
{
    public partial class LoanedBook : Book
    {
        public DateTime DateTimeRequested { get; set; }
        public DateTime DateTimeToReturn { get; set; }
        public double? DailyFee { get; set; }
        public string LibraryId { get; set; }
        public bool? Returned { get; set; }
        public DateTime? DateTimeReturned { get; set; }
        private int DueDays { get; set; }

        public LoanedBook()
        {

        }

        public LoanedBook(string title, string description, DateTime dateRequested, DateTime dateToReturn, string libraryId, double? fee = 0)
        {
            Title = title;
            Description = description;
            DateTimeToReturn = dateToReturn;
            DateTimeRequested = dateRequested;
            LibraryId = libraryId;
            DailyFee = fee;
            DueDays = 0;
            Returned = false;
        }
      
    }
}
