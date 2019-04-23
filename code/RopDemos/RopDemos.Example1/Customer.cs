namespace RopDemos.Example1
{
    public class Customer
    {
        public CustomerName CustomerName { get; }

        public Customer(CustomerName customerName)
        {
            CustomerName = customerName;
        }
    }
}