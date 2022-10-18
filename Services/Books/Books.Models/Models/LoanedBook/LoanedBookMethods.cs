using System;
using System.Text;

namespace Books.Data.Models.LoanedBook
{
    public partial class LoanedBook
    {

        public void UpdatePastDueFromDate(DateTime date)
        {
            var daysPassedSinceDueDate = date.DayOfYear - DateTimeToReturn.DayOfYear;
            if(daysPassedSinceDueDate > 0)
            {
                PastDueXDays(daysPassedSinceDueDate);
            }
        }

        public bool CheckIfInDue(DateTime dateTimeToCompare)
        {
            return dateTimeToCompare.DayOfYear > DateTimeToReturn.DayOfYear;
        }

        public void CalculateIfInDue()
        {
            var dueDays = DateTimeRequested.DayOfYear - DateTimeToReturn.DayOfYear;
            if (dueDays > 0)
            {
                DueDays = dueDays;
            }
        }

        public void ExtendDateTimeToReturn(DateTime newDateTimeToReturn)
        {
            DateTimeToReturn = newDateTimeToReturn;
        }

        public void UpdateDailyFee(double dailyFee)
        {
            DailyFee = dailyFee;
        }

        public void PastDueOneDay()
        {
            DueDays += 1;
        }

        public void PastDueXDays(int numberOfDays)
        {
            DueDays = numberOfDays;
        }

        public double GetAccruedFee()
        {
            return DueDays * DailyFee.Value;
        }
        public void Return(DateTime returnedDatetime)
        {
            Returned = true;
            DateTimeReturned = returnedDatetime;
        }
    }
}
