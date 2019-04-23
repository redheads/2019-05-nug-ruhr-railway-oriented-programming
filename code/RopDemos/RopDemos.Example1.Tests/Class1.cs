using System;
using FluentAssertions;
using Xunit;

namespace RopDemos.Example1.Tests
{
    public class Class1
    {
        [Fact]
        public void FactMethodName()
        {
            true.Should().BeTrue();
        }
    }
}
