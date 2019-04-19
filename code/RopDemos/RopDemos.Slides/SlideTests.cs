using FluentAssertions;
using Xunit;

namespace RopDemos.Slides
{
    public class SlideTests
    {
        [Fact]
        public void SmokeTest()
        {
            true.Should().BeTrue();
        }
    }
}