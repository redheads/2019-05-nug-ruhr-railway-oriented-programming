using LanguageExt;
using static LanguageExt.Prelude;

namespace RopDemos.Example2
{
    public class Customer
    {
        public CustomerName CustomerName { get; }

        private Customer(CustomerName customerName)
        {
            CustomerName = customerName;
        }

        public static Either<string, Customer> TryCreate(CustomerName customerName)
        {
            return Right(new Customer(customerName));
        }
    }
}