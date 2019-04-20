using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
// ReSharper disable ClassNeverInstantiated.Global

namespace RopDemos.Slides
{
    public class SlideTests
    {
        public class NullIsAPain
        {
            [Fact]
            public void String_is_a_pain0()
            {
                Assert.False(string.IsNullOrWhiteSpace("x"));
            }

            [Fact]
            public void Collections_are_a_pain0()
            {
                var collection = new List<string> {"x"};
                if (collection != null && collection.Any())
                {
                    Assert.True(true);
                }
            }

            [Fact]
            public void Nested_validations_are_a_pain0()
            {
                var customer = new Customer
                {
                    Address = new Address
                    {
                        ZipCode = new ZipCode()
                    }
                };

                if (customer?.Address?.ZipCode != null)
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(false);
                }
            }

            private class Customer
            {
                public Address Address { get; set; }
            }

            private class Address
            {
                public ZipCode ZipCode { get; set; }
            }

            private class ZipCode{}
        }

        public class ErrorsAreAPain
        {
            [Fact]
            public void Addition_can_fail()
            {
                int Add(int a, int b) => a + b;

                var i1 = int.MaxValue - 1;
                var i2 = 1;

                var result = Add(i1, i2);
                result.Should().Be(int.MaxValue);
            }
        }
    }
}