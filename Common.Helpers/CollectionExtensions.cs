using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Common.Helpers
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this Collection<T> collection, IEnumerable<T> items)
        {
            Argument.RequiresNonNullValue("collection", collection);
            Argument.RequiresNonNullValue("items", items);
            foreach (var item in items)
                collection.Add(item);
        }

        [DebuggerNonUserCode]
        public static void RequiresNonEmptyString(string argumentName, string value)
        {
            if (value == null)
                throw new ArgumentNullException(argumentName);
            if (value == string.Empty)
                throw new ArgumentOutOfRangeException(argumentName, "Value cannot be empty.");
        }
    }
}
