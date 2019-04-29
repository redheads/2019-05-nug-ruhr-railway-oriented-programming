using LanguageExt;

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
            return Prelude.Right(new Customer(customerName));
        }
    }
}