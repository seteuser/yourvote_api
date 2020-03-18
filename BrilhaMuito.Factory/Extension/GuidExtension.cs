using System;
using System.Diagnostics;

namespace BrilhaMuito.Factory.Extension
{
    public static  class GuidExtension
    {
        [DebuggerStepThrough]
        public static bool IsEmpty(this Guid target)
        {
            return target == Guid.Empty;
        }
    }
}