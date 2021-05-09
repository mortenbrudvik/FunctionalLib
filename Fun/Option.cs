using System;
using Ardalis.GuardClauses;
using Unit = System.ValueTuple;
using static Fun.Predlude;

namespace Fun
{
    public class Option<T> : IEquatable<Option<T>>
    {
        public Option()
        {
            HasValue = false;
        }

        public Option(T value)
        {
            if(value==null)
                throw new ArgumentNullException(nameof(Value));
        
            Value = value;
            HasValue = true;
        }

        internal T Value { get; }
        internal bool HasValue { get; }
        internal bool HasNoValue => !HasValue;
        
        public static implicit operator Option<T>(Option.None _) => new();
        public static implicit operator Option<T>(Option.Some<T> some) => new(some.Value);
        public static implicit operator Option<T>(T value) => value == null ? None : new Option<T>(value);

        public bool Equals(Option<T> other) =>
            other switch
            {
                {HasNoValue: true} when HasNoValue => true,
                _ when other == null || other.HasNoValue || HasNoValue => false,
                _ => Value.Equals(other.Value)
            };

        public override bool Equals(object obj) =>
            obj is Option<T> other && Equals(other);

        public override int GetHashCode() =>
            HasValue ? Value.GetHashCode() : 0;
    }
    
    public static partial class Predlude
    {
        public static Unit Unit() => default;
        public static Option<T> Some<T>(T value) => new Option.Some<T>(value);
        public static Option.None None => Option.None.Default;
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
