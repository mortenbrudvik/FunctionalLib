using FluentAssertions;
using Functional;
using Xunit;

using static Functional.F;

namespace UnitTests
{
    public class OptionsTests
    {
        [Fact]
        public void Match_when_some_value()
        {
            var result = Parse("1");

            result.Match(() => false, (_) => true)
                .Should().BeTrue();
        }
        
        [Fact]
        public void Match_when_none_value()
        {
            var result = Parse("hello");

            result.Match(() => false, (_) => true)
                .Should().BeFalse();
        }
        
        Option<int> Parse(string strNumber) 
            => int.TryParse(strNumber, out var intNumber) 
                ? Some(intNumber) : None;
    }
}
