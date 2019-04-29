using LanguageExt;

namespace RopDemos.Example2
{
    public interface IMailService
    {
        Either<string, Customer> SendGreeting(Customer customer);
    }
}