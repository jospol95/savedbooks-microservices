using System;
using System.Text;

namespace Books.Data.Models.LoanedBook
{
    public partial class LoanedBook
    {
        public void CalculateDue(DateTime? date)
        {
            date = date ?? DateTime.Now;
            _accumulatedFee = GetAccumulatedFee(date.Value);
        }

        public double GetAccumulatedFee(DateTime todaysDate)
        {
            var dueDays = GetDueDays(todaysDate);
            if (dueDays < 1) return 0;

            return DailyFee * dueDays;
            
        }

        public int GetDueDays(DateTime todaysDate)
        {
            //Comparing 10/24 agaisnt 10/22 returns 1. should be 2
            var diff = todaysDate - DateTimeToReturn;
            return (int)Math.Ceiling(diff.TotalDays); ;
        }

        //public void CalculateIfInDue()
        //{
        //    var dueDays = DateTimeBorrowed.DayOfYear - DateTimeToReturn.DayOfYear;
        //    if (dueDays > 0)
        //    {
        //        DueDays = dueDays;
        //    }
        //}

        //public void Return(DateTime returnedDatetime)
        //{
        //    Returned = true;
        //    DateTimeReturned = returnedDatetime;
        //}
    }
}
