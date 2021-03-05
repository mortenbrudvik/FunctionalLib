using System.Collections.Generic;
using FluentAssertions;
using Functional;
using Xunit;

namespace UnitTests
{
    public class DictionaryExtTests
    {
        [Fact]
        public void Lookup_when_value_exist()
        {
            var dict = new Dictionary<string, string> {{"1", "Some"}};

            dict.Lookup("1")
                .Match(()=>false, v=>v == "Some")
                .Should().BeTrue();
        }
        
        [Fact]
        public void Lookup_when_value_does_not_exist()
        {
            var dict = new Dictionary<string, string> {{"1", "Some"}};
            
            dict.Lookup("2")
                .Match(()=>false, v => v == "Some")
                .Should().BeFalse();
        }
    }
}