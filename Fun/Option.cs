using System;

namespace Fun
{
    public class Option<T> : IEquatable<Option<T>>
    {
        public Option()
        {
            HasValue = false;
        }

        private Option(T value)
        {
            if(value==null)
                throw new ArgumentNullException(nameof(Value));
        
            Value = value;
            HasValue = true;
        }

        internal T Value { get; }
        internal bool HasValue { get; }
        internal bool HasNoValue => !HasValue;

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
}
