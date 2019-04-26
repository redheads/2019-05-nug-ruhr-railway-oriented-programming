using FluentAssertions;
using Xunit;

namespace RopDemo.Example2.Tests
{
    public class CustomerNameTests
    {
        [Fact]
        public void Valid_name_returns_either_with_correct_value()
        {
            var either = CustomerName.TryCreate("valid");
            either.IsRight.Should().BeTrue();
            either.Match(
                x => x.Value.Should().Be("valid"),
                x => x.Should().Be("should never happen"));
        }
    }
}