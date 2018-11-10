using System;
using System.Collections.Generic;
using System.Linq;

namespace Appius.Core.Utility.Extensions
{
    public static class EnumeratorExtensions
    {
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }
}
