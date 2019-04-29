namespace RopDemos.Example2
{
    public class RegistrationService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMailService _mailService;

        public RegistrationService(
            ICustomerRepository customerRepository, 
            IMailService mailService)
        {
            _customerRepository = customerRepository;
            _mailService = mailService;
        }

        public RegistrationResponse RegisterNewCustomer_Error_Handling2(string name)
        {
            var customerNameEither = CustomerName.TryCreate(name);
            var result = customerNameEither
                .Bind(Customer.TryCreate)
                .Bind(x => _customerRepository.Save(x))
                .Bind(x => _mailService.SendGreeting(x))
                .Match(
                    RegistrationResponse.Success,
                    RegistrationResponse.Fail);

            return result;
        }
    }
}