using System;
using Ardalis.GuardClauses;

namespace Functional
{
    using static F;
    
    public static partial class F
    {
        public static Option<T> Some<T>(T value) => new Option.Some<T>();
        public static Option.None None => Option.None.Default;
    }
    
    public struct Option<T> 
    {
        readonly T _value;
        readonly bool _isSome;
        
        private Option(T value)
        {
            _value = Guard.Against.Null(value, nameof(value));
            _isSome = true;
        }
        
        public static implicit operator Option<T>(Option.None _) => new();
        public static implicit operator Option<T>(Option.Some<T> some) => new(some.Value);
        public static implicit operator Option<T>(T value) => value == null ? None : Some(value);
        
        public R Match<R>(Func<R> none, Func<T, R> some)
            => _isSome ? some(_value) : none();
    }

    namespace Option
    {
        public struct None
        {
            internal static readonly None Default = new();
        }

        public struct Some<T>
        {
            internal T Value { get; }

            internal Some(T value) 
                => Value = Guard.Against.Null(value, nameof(value));
        }
    }
}
