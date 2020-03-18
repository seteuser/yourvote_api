using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BrilhaMuito.Factory.Extension;

namespace BrilhaMuito.Factory.Helper
{
    public class Argument
    {
        internal Argument()
        {
        }

        [DebuggerStepThrough]
        public static void IsNotEmpty(Guid argument)
        {
            if (argument == Guid.Empty)
            {
                throw new ArgumentException("Cannot be empty Id.");
            }
        }

        [DebuggerStepThrough]
        public static void IsNotEmpty(string argument, string argumentName)
        {
            if (string.IsNullOrEmpty((argument ?? string.Empty).Trim()))
            {
                throw new ArgumentException($"{argumentName} cannot be empty.");
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException($"{argumentName} cannot be blank");
            }
        }

        [DebuggerStepThrough]
        public static void IsNotEmpty<T>(IEnumerable<T> argument, string argumentName)
        {
            if (!argument.Any())
            {
                throw new ArgumentException($"{argumentName} cannot be empty.");
            }
        }

        [DebuggerStepThrough]
        public static void AreEquals(Guid argument1, Guid argument2, string argumentName)
        {
            if (!argument1.Equals(argument2))
            {
                throw new ArgumentNullException(argumentName);
            }
        }
        [DebuggerStepThrough]
        public static void IsNotInvalidDate(DateTime argument, string argumentName)
        {
            if (!argument.IsValid())
            {
                throw new ArgumentOutOfRangeException($"Invalid {argumentName}: {argument}\n");
            }
        }
        [DebuggerStepThrough]
        public static void IsNotInvalidEmail(string argument, string argumentName)
        {
            IsNotEmpty(argument, argumentName);

            if (!argument.IsEmail())
            {
                throw new ArgumentException($"{argumentName} is not a valid email address.");
            }
        }
    }
}