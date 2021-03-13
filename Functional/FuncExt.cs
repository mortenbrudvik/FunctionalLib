using System;

namespace Functional
{
    using static Fun;

    public static class FuncExt
    {
        public static Func<T2, R> Apply<T1, T2, R>(this Func<T1, T2, R> func, T1 t1)
            => t2 => func(t1, t2);

        public static Func<T2, T3, R> Apply<T1, T2, T3, R>(this Func<T1, T2, T3, R> func, T1 t1)
            => (t2, t3) => func(t1, t2, t3);

        public static Func<T2, T3, T4, R> Apply<T1, T2, T3, T4, R>(this Func<T1, T2, T3, T4, R> func, T1 t1)
            => (t2, t3, t4) => func(t1, t2, t3, t4);

        public static Func<T2, T3, T4, T5, R> Apply<T1, T2, T3, T4, T5, R>(this Func<T1, T2, T3, T4, T5, R> func, T1 t1)
            => (t2, t3, t4, t5) => func(t1, t2, t3, t4, t5);

        public static Func<T2, T3, T4, T5, T6, R> Apply<T1, T2, T3, T4, T5, T6, R>(this Func<T1, T2, T3, T4, T5, T6, R> func, T1 t1)
            => (t2, t3, t4, t5, t6) => func(t1, t2, t3, t4, t5, t6);

        public static Func<T2, T3, T4, T5, T6, T7, R> Apply<T1, T2, T3, T4, T5, T6, T7, R>(this Func<T1, T2, T3, T4, T5, T6, T7, R> func, T1 t1)
            => (t2, t3, t4, t5, t6, t7) => func(t1, t2, t3, t4, t5, t6, t7);

        public static Func<T2, T3, T4, T5, T6, T7, T8, R> Apply<T1, T2, T3, T4, T5, T6, T7, T8, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, R> func, T1 t1)
            => (t2, t3, t4, t5, t6, t7, t8) => func(t1, t2, t3, t4, t5, t6, t7, t8);

        public static Func<T2, T3, T4, T5, T6, T7, T8, T9, R> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> func, T1 t1)
            => (t2, t3, t4, t5, t6, t7, t8, t9) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
    }
}