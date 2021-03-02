using System;
using Ardalis.GuardClauses;

namespace Functional
{
    using static Fun;
    
    public static class Fun
    {
        public static Option<T> Some<T>(T value) => new Option.Some<T>(value);
        public static Option.None None => Option.None.Default;
    }
    
    public struct Option<T> 
    {
        private readonly T _value;
        private readonly bool _isSome;
        
        private Option(T value)
        {
            _value = Guard.Against.Null(value, nameof(value));
            _isSome = true;
        }
        
        public static implicit operator Option<T>(Option.None _) => new();
        public static implicit operator Option<T>(Option.Some<T> some) => new(some.Value);
        public static implicit operator Option<T>(T value) => value == null ? None : Some(value);
        
        public R Match<R>(Func<R> None, Func<T, R> Some) 
            => _isSome ? Some(_value) : None();
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
}
