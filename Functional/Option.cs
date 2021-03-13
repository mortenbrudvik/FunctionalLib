using System;
using System.Collections.Generic;
using Ardalis.GuardClauses;
using Unit = System.ValueTuple;

namespace Functional
{
    using static Fun;
    
    public static partial class Fun
    {
        public static Option<T> Some<T>(T value) => new Option.Some<T>(value);
        public static Option.None None => Option.None.Default;
    }
    
    public readonly struct Option<T>  : IEquatable<Option.None>, IEquatable<Option<T>> 
    {

        internal T Value { get; }
        public  bool IsSome { get; }
        public  bool IsNone => !IsSome;

        private Option(T value)
        {
            Value = Guard.Against.Null(value, nameof(value));
            IsSome = true;
        }
        
        public static implicit operator Option<T>(Option.None _) => new();
        public static implicit operator Option<T>(Option.Some<T> some) => new(some.Value);
        public static implicit operator Option<T>(T value) => value == null ? None : Some(value);
        
        public TR Match<TR>(Func<TR> onNone, Func<T, TR> onSome) 
            => IsSome ? onSome(Value) : onNone();
        
        public IEnumerable<T> AsEnumerable()
        {
            if (IsSome) yield return Value;
        }
        
        public bool Equals(Option<T> other) 
            => IsSome == other.IsSome 
               && (IsNone || Value.Equals(other.Value));

        public bool Equals(Option.None _) => IsNone;

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != typeof(Option<T>))
            {
                if (obj is T)
                    obj = new Option<T>((T)obj);

                if (!(obj is Option<T>))
                    return false;
            }
            return Equals((Option<T>)obj);
        }

        public override int GetHashCode() => IsNone ? 0 : Value.GetHashCode();

        public static bool operator ==(Option<T> first, Option<T> second) => first.Equals(second);
        public static bool operator !=(Option<T> first, Option<T> second) => !(first == second);

        public override string ToString() => IsSome ? $"Some({Value})" : "None";
    }

    namespace Option
    {
        public struct None
        {
            internal static readonly None Default = new();
        }

        public readonly struct Some<T>
        {
            internal T Value { get; }
            internal Some(T value) => Value = Guard.Against.Null(value, nameof(value));
        }
    }

    public static class OptionExt
    {
        public static Option<TR> Map<T, TR>
            (this Option.None _, Func<T, TR> f)
            => None;
        
        public static Option<TR> Map<T, TR>
            (this Option.Some<T> some, Func<T, TR> f) 
            => Some(f(some.Value));
        
        public static Option<TR> Map<T, TR>(this Option<T> optT, Func<T, TR> f)
            => optT.Match(
                () => None,
                (t) => Some(f(t)));
        
        public static Option<R> Bind<T, R>(this Option<T> optT, Func<T, Option<R>> f)
            => optT.Match(
                () => None,
                t => f(t));
        
        public static IEnumerable<R> Bind<T, R>(this Option<T> opt, Func<T, IEnumerable<R>> func)
            => opt.AsEnumerable().Bind(func);
        
        public static Option<T> Where<T>
            (this Option<T> optT, Func<T, bool> pred)
            => optT.Match(
                () => None,
                (t) => pred(t) ? optT : None);
        
        public static Option<Unit> ForEach<T>(this Option<T> opt, Action<T> action)
            => Map(opt, action.ToFunc());
        
        public static Unit Match<T>(this Option<T> optT, Action onNone, Action<T> onSome)
            => optT.Match(onNone.ToFunc(), onSome.ToFunc());
    }
}
