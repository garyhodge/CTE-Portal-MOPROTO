using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appius.Core.Utility.Extensions
{
    public static class GeneralExtensions
    {
        public static TResult IfNotDefault<TResult, TSource>(this TSource source, Func<TSource, TResult> callback, Func<TResult> getDefault = null, TSource emptySourceValue = default(TSource))
        {
            return EqualityComparer<TSource>.Default.Equals(source, emptySourceValue) ? (getDefault ?? (() => default(TResult)))() : callback(source);
        }
    }
}
