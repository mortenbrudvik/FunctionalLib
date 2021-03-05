using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using Functional;
using JetBrains.Annotations;
using Xunit;

using static Functional.Fun;

namespace UnitTests
{
    public class OptionsTests
    {
        [Fact]
        public void Option_testing_conversion()
        {
            Option<int> noneOpt = None;

            Assert.True(noneOpt == None);
            Assert.True(Some(1) == 1);
            Assert.True(Some(1) != 2);
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
        
        [Fact]
        public void Map_option_of_none_and_some()
        {
            var age = Some(22);

            age.Map(x => x + 1)
                .Should().Be(Some(23));

            age = None;
            age.Map(x => x + 1)
                .IsNone.Should().BeTrue();
        }
    }
}
