using LanguageExt;

namespace RopDemos.Example2
{
    public interface ICustomerRepository
    {
        Either<string, Customer> Save(Customer customer);
    }
}