using CSharpFunctionalExtensions;

namespace RopDemos.Example1
{
    public class CustomerName
    {
        public string Value { get; }

        private CustomerName(string value)
        {
            Value = value;
        }

        public static Result<CustomerName> TryCreate(string name)
            => string.IsNullOrWhiteSpace(name)
                ? Result.Fail<CustomerName>("invalid name")
                : Result.Ok(new CustomerName(name));
    }
}