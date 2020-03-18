using System;

namespace BrilhaMuito.Domain.Account.Entities
{
    public class Interval
    {
        public Interval(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
        public Interval() { }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return $"Start: {StartDate}, End: {EndDate}";
        }
    }
}