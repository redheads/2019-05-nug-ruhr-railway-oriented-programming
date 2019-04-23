using CSharpFunctionalExtensions;

namespace RopDemos.Example1
{
    public interface IMailService
    {
        Result<Customer> SendGreeting(Customer customer);
    }
}