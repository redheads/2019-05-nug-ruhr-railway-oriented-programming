using LanguageExt;

namespace RopDemo.Example2
{
    public interface ICustomerRepository
    {
        Either<string, Customer> Save(Customer customer);
    }
}