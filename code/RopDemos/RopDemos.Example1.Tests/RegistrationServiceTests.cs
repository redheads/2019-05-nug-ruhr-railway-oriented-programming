﻿using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace RopDemos.Example1.Tests
{
    public class RegistrationServiceTests
    {
        [Fact]
        public void Registering_valid_customer_happy_path_works()
        {
            // Arrange
            var customer = new Customer(CustomerName.TryCreate("test").Value);

            var customerRepository = Substitute.For<ICustomerRepository>();

            customerRepository
                .Save(Arg.Any<Customer>())
                .Returns(Result.Ok(customer));

            var mailService = Substitute.For<IMailService>();

            mailService
                .SendGreeting(Arg.Any<Customer>())
                .Returns(Result.Ok(customer));

            var sut = new RegistrationService(customerRepository, mailService);

            // Act
            var result = sut.RegisterNewCustomer_NoError_Handling("test");

            // Assert
            result.Should()
                .BeEquivalentTo(RegistrationResponse.Success(customer));
        }

        [Fact]
        public void Registering_invalid_customer_should_have_correct_error()
        {
            // Arrange
            var customer = new Customer(CustomerName.TryCreate("test").Value);

            var customerRepository = Substitute.For<ICustomerRepository>();

            customerRepository
                .Save(Arg.Any<Customer>())
                .Returns(Result.Ok(customer));

            var mailService = Substitute.For<IMailService>();

            mailService
                .SendGreeting(Arg.Any<Customer>())
                .Returns(Result.Ok(customer));

            var sut = new RegistrationService(customerRepository, mailService);

            // Act
            var result = sut.RegisterNewCustomer_Error_Handling1("");

            // Assert
            result.Should()
                .BeEquivalentTo(RegistrationResponse.Fail("invalid name"));
        }

        [Fact]
        public void Registering_invalid_customer_rop_should_have_correct_error()
        {
            // Arrange
            var customer = new Customer(CustomerName.TryCreate("test").Value);

            var customerRepository = Substitute.For<ICustomerRepository>();

            customerRepository
                .Save(Arg.Any<Customer>())
                .Returns(Result.Ok(customer));

            var mailService = Substitute.For<IMailService>();

            mailService
                .SendGreeting(Arg.Any<Customer>())
                .Returns(Result.Ok(customer));

            var sut = new RegistrationService(customerRepository, mailService);

            // Act
            var result = sut.RegisterNewCustomer_Error_Handling2("");

            // Assert
            result.Should()
                .BeEquivalentTo(RegistrationResponse.Fail("invalid name"));
        }

        [Fact]
        public void Null_collections_are_still_a_problem()
        {
            var result = Result.Ok<List<string>>(null);
            var finalResult = result
                .OnSuccess(x => x.Take(50))
                .OnBoth(x => x.IsSuccess
                    ? "ok"
                    : "ups");

            finalResult.Should().Be("ok");
        }


    }
}