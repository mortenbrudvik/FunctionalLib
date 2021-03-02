using System;
using FluentAssertions;
using Functional;
using Xunit;

using static Functional.Fun;

namespace UnitTests
{
    public class OptionsTests
    {
        [Fact]
        public void Match_when_Some_value()
        {
            var result = Parse("1");

            result.Match(None: () => false, Some: (n) => n == 1)
                .Should().BeTrue();
        }
        
        [Fact]
        public void Match_when_None_value()
        {
            var result = Parse("hello");

            result.Match(None: () => false, Some: (_) => true)
                .Should().BeFalse();
        }

        private static Option<int> Parse(string strNumber) 
            => int.TryParse(strNumber, out var intNumber) 
                ? Some(intNumber) : None;
    }
}
