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
            var customer = new Customer(CustomerName.Create("test").Value);

            var customerRepository = Substitute.For<ICustomerRepository>();

            customerRepository
                .Save(Arg.Any<Customer>())
                .Returns(Result.Ok(customer));

            var mailService = Substitute.For<IMailService>();

            mailService
                .SendGreeting(Arg.Any<Customer>())
                .Returns(Result.Ok(customer));

            var sut = new RegistrationService(customerRepository, mailService);

            var result = sut.RegisterNewCustomer_NoError_Handling("test");

            result.Should().BeEquivalentTo(new RegistrationResponse(customer));
        }
    }
}