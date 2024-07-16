using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class Argument
    {
        [DebuggerNonUserCode]
        public static void RequiresNonNullValue(string argumentName, object value)
        {
            if (value == null)
                throw new ArgumentNullException(argumentName);
        }

        [DebuggerNonUserCode]
        public static void RequiresNonEmptyString(string argumentName, string value)
        {
            if (value == null)
                throw new ArgumentNullException(argumentName);
            if (value == string.Empty)
                throw new ArgumentOutOfRangeException(argumentName, "Value cannot be empty.");
        }
        [DebuggerNonUserCode]
        public static void Requires(string argumentName, bool condition, string message)
        {
            if (!condition)
                throw new ArgumentException(message, argumentName);
        }
    }
}
