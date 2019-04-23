using CSharpFunctionalExtensions;

namespace RopDemos.Example1
{
    public interface ICustomerRepository
    {
        Result<Customer> Save(Customer customer);
    }
}