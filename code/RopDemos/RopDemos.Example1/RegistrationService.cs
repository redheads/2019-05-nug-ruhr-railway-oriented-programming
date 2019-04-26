using CSharpFunctionalExtensions;

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
            var customerNameResult = CustomerName.TryCreate(name);
            var customer = new Customer(customerNameResult.Value);

            var customerResult = _customerRepository.Save(customer);

            var greetingResult = _mailService.SendGreeting(customerResult.Value);

            return RegistrationResponse.Success(greetingResult.Value);
        }

        public RegistrationResponse RegisterNewCustomer_Error_Handling1(string name)
        {
            var customerNameResult = CustomerName.TryCreate(name);
            if (customerNameResult.IsFailure)
            {
                return RegistrationResponse.Fail(customerNameResult.Error);
            }

            var customer = new Customer(customerNameResult.Value);

            var customerResult = _customerRepository.Save(customer);
            if (customerResult.IsFailure)
            {
                return RegistrationResponse.Fail(customerResult.Error);
            }


            var greetingResult = _mailService.SendGreeting(customerResult.Value);
            if (greetingResult.IsFailure)
            {
                return RegistrationResponse.Fail(greetingResult.Error);
            }

            return RegistrationResponse.Success(greetingResult.Value);
        }

        public RegistrationResponse RegisterNewCustomer_Error_Handling2(string name)
        {
            var customerNameResult = CustomerName.TryCreate(name);

            var result = customerNameResult
                .OnSuccess(x => Result.Ok(new Customer(x)))
                .OnSuccess(x => _customerRepository.Save(x))
                .OnSuccess(x => _mailService.SendGreeting(x))
                .OnBoth(x => x.IsSuccess
                    ? RegistrationResponse.Success(x.Value)
                    : RegistrationResponse.Fail(x.Error));

            return result;
        }
    }
}
