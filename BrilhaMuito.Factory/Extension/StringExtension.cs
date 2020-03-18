using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace BrilhaMuito.Factory.Extension
{
    public static class StringExtension
    {
        private static readonly Regex EmailExpression = new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$", RegexOptions.Singleline | RegexOptions.Compiled);

        [DebuggerStepThrough]
        public static bool IsEmail(this string target)
        {
            return !string.IsNullOrEmpty(target) && EmailExpression.IsMatch(target);
        }

        [DebuggerStepThrough]
        public static int MyAge(this DateTime birthday)
        {
            var today = DateTime.Today;
            int age = today.Year - birthday.Year;
            if (today < birthday.AddYears(age)) age--;

            return age;
        }
    }
}