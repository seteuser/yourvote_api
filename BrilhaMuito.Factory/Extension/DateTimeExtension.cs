﻿using System;
using System.Diagnostics;

namespace BrilhaMuito.Factory.Extension
{
    public static class DateTimeExtension
    {
        private static readonly DateTime MinDate = new DateTime(1900, 1, 1);
        private static readonly DateTime MaxDate = new DateTime(9999, 12, 31, 23, 59, 59, 999);

        [DebuggerStepThrough]
        public static bool IsToday(this DateTime target)
        {
            var today = DateTime.Today;
            return (target.Day == today.Day) && (target.Month == today.Month) && (target.Year == today.Year);
        }

        [DebuggerStepThrough]
        public static bool IsValid(this DateTime target)
        {
            return (target >= MinDate) && (target <= MaxDate);
        }

    }
}