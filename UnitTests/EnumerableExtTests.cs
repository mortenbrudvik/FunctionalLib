using System;
using System.Linq;
using FluentAssertions;
using Functional;
using Xunit;

using static Functional.Fun;

namespace UnitTests
{
    public class EnumerableExtTests
    {
        [Fact]
        public void Map_should_work_the_same_as_select()
        {
            var cars = new[] {"Volvo", "Toyota", "Honda"};

            cars.Map(x => x + 1)
                .Should().BeEquivalentTo(cars.Select(x => x+1));
        }
        
        [Fact]
        public void Foreach_should_run_action_on_each()
        {
            var sum = 0;
            Enumerable.Range(1, 10).ForEach(i => sum += i);
            sum.Should().Be(55);
        }
        
        [Fact]
        public void Bind_binding_list_after_mapping_with_option()
        {
            var cars = new[] {"Volvo", "Toyota", "Honda"};
            
            cars.Map(Some)
                .Bind(x=>x).ToList()
                .Should().BeEquivalentTo(cars);
        }
    }
}