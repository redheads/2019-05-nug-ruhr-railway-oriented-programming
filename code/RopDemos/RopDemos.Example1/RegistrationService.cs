namespace RopDemos.Example1
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

        public RegistrationResponse RegisterNewCustomer_NoError_Handling(string name)
        {
            var customerNameResult = CustomerName.Create(name);
            var customer = new Customer(customerNameResult.Value);

            var customerResult = _customerRepository.Save(customer);

            var greetingResult = _mailService.SendGreeting(customerResult.Value);

            return RegistrationResponse.Success(greetingResult.Value);
        }

        public RegistrationResponse RegisterNewCustomer_Error_Handling1(string name)
        {
            var customerNameResult = CustomerName.Create(name);
            if (customerNameResult.IsFailure)
            {
                return RegistrationResponse.Fail("invalid customer name");
            }

            var customer = new Customer(customerNameResult.Value);

            var customerResult = _customerRepository.Save(customer);
            if (customerResult.IsFailure)
            {
                return RegistrationResponse.Fail("failure saving customer");
            }


            var greetingResult = _mailService.SendGreeting(customerResult.Value);
            if (greetingResult.IsFailure)
            {
                return RegistrationResponse.Fail("failure sending greeting mail");
            }

            return RegistrationResponse.Success(greetingResult.Value);
        }
    }
}
