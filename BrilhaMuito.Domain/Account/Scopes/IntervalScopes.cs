using System;
using System.Collections.Generic;
using BrilhaMuito.Domain.Account.Entities;

namespace BrilhaMuito.Domain.Account.Scopes
{
    public static class IntervalScopes
    {
        public static bool IsEmpty(this Interval interval)
        {
            return interval.StartDate == DateTime.MinValue && interval.EndDate == DateTime.MinValue;
        }

        public static Interval ToInterval(this IDictionary<string, object> dictionary)
        {
            var startDate = Convert.ToDateTime(dictionary["StartDate"].ToString());
            var endDate = Convert.ToDateTime(dictionary["EndDate"].ToString());
            return new Interval(startDate, endDate);
        }
    }
}