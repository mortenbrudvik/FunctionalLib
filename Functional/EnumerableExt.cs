using System;
using System.Collections.Generic;

namespace Functional
{
    public static class EnumerableExt
    {
        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> f)
        {
            foreach (var t in ts)
                yield return f(t);
        }
    }
}