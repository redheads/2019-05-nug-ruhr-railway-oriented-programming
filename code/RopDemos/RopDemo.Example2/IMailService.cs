using LanguageExt;

namespace RopDemo.Example2
{
    public interface IMailService
    {
        Either<string, Customer> SendGreeting(Customer customer);
    }
}