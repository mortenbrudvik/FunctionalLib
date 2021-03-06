using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Unit = System.ValueTuple;

using static Functional.Fun;

namespace Functional
{
    public static class EnumerableExt
    {
        public static IEnumerable<TR> Map<T, TR>(this IEnumerable<T> ts, Func<T, TR> f)
        {
            foreach (var t in ts)
                yield return f(t);
        }
        
        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> ts, Func<T, IEnumerable<R>> f)
        {
            foreach (T t in ts)
               foreach (R r in f(t))
                    yield return r;
        }
        
        public static IEnumerable<R> Bind<T, R>(this IEnumerable<T> list, Func<T, Option<R>> func)
            => list.Bind(t => func(t).AsEnumerable());
        
        public static IEnumerable<Unit> ForEach<T>(this IEnumerable<T> ts, Action<T> action)
            => ts.Map(action.ToFunc()).ToImmutableList();
    }
}