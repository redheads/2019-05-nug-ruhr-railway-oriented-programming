using CSharpFunctionalExtensions;

namespace RopDemos.Example1
{
    public class CustomerName
    {
        public string Value { get; }

        public CustomerName(string value)
        {
            Value = value;
        }

        public static Result<CustomerName> Create(string name)
        {
            return Result.Ok(new CustomerName(name));
        }
    }
}