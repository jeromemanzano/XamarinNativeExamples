using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class SystemExtensions
    {
        public static bool IsNullOrEmpty<TItem>(this IEnumerable<TItem> self)
        {
            return self == null || !self.Any();
        }
    }
}
