using Books.Data.Models;
using Books.Data.Models.Libraries;
using Libraries.Data.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Data.Models.LoanedBook
{
    public partial class LoanedBook : Book
    {
        public DateTime DateTimeBorrowed { get; set; }
        public DateTime DateTimeToReturn { get; set; }
        public double DailyFee { get; set; }
        public bool? Returned { get; set; }
        public DateTime? DateTimeReturned { get; set; }
        public Library Library { get; set; }
        //public double AccumulatedFee { get; set; }
        [NotMapped]
        private double _accumulatedFee;
        public double AccumulatedFee
        {
            get =>  _accumulatedFee; 
            set => _accumulatedFee = value;

        }

        public LoanedBook()
        {
            Library = new Library();
            //If the fee is not given, we'll set up to 0;
            DailyFee = 0;
        }
      
    }
}
