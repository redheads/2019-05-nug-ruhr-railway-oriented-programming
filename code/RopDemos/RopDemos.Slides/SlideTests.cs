using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using RopDemos.Slides.MyResult;
using Xunit;
// ReSharper disable ClassNeverInstantiated.Global

namespace RopDemos.Slides
{
    public partial class SlideTests
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

        public class RopSingleTrack
        {
            [Fact]
            public void F1Demo0()
            {
                string f1(string input) => input.ToUpper();
                var result = f1("abc");
                result.Should().Be("ABC");
            }

            [Fact]
            public void F2_with_inner_F1()
            {
                string f1(string input) => input.ToUpper();
                int    f2(string input) => input.Length;

                var r1 = f1("abc");
                var r2 = f2(r1);

                r2.Should().Be(3);
            }

            [Fact]
            public void F12_combines_F1_and_F2()
            {
                string f1 (string input) => input.ToUpper();
                int    f2 (string input) => input.Length;

                int    f12(string input) => f2(f1(input)); // "Composition"

                var result = f12("abc");

                result.Should().Be(3);
            }
        }

        public partial class RopSingleTrackWithSwitch
        {
            [Fact]
            public void Playing_with_MyResult_creating_success()
            {
                // creating result
                var result = "x".Success<string, string>();
                
                // some sane assertions
                result.IsSuccess.Should().BeTrue();
                result.SuccessValue.Should().Be("x");
            }

            [Fact]
            public void Playing_with_MyResult_creating_failure()
            {
                // creating result
                var result = "ups".Failure<string, string>();
                
                // some sane assertions
                result.IsSuccess.Should().BeFalse();
                result.FailureValue.Should().Be("ups");
            }
        }
    }
}