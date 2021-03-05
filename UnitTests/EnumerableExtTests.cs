using System.Linq;
using FluentAssertions;
using Functional;
using Xunit;

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
    }
}