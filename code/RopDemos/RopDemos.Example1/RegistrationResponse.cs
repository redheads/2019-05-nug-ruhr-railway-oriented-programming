namespace RopDemos.Example1
{
    public class RegistrationResponse
    {
        public Customer Customer { get; }

        public RegistrationResponse(Customer customer)
        {
            Customer = customer;
        }
    }
}