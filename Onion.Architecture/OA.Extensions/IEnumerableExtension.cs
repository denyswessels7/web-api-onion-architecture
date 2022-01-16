using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class IEnumerableExtension
    {
        public static bool NoItems<T>(this IEnumerable<T> items)
        {
            var result = items == null || items.Count() == 0;
            return result;
        }

        public static bool HasItems<T>(this IEnumerable<T> items)
        {
            var result = items != null && items.Count() > 0;
            return result;
        }
    }
}
