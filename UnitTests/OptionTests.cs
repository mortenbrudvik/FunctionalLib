using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Functional;
using Xunit;

using static Functional.Fun;

namespace UnitTests
{
    public class OptionsTests
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
        
        [Fact]
        public void Int_parse_string_to_int()
        {
            Int.Parse("1")
                .Match(() => false, n => n == 1)
                .Should().BeTrue();
        }
        
        [Fact]
        public void Int_parse_string_to_int_when_string_is_not_a_int()
        {
            Int.Parse("Fun")
                .Match(() => true, n => false)
                .Should().BeTrue();
        }
    }
}
