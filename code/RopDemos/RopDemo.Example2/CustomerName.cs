using LanguageExt;
using static LanguageExt.Prelude;

namespace RopDemo.Example2
{
    public class CustomerName
    {
        public string Value { get; }

        private CustomerName(string value)
        {
            Value = value;
        }

        public static Either<string, CustomerName> TryCreate(string name) =>
            string.IsNullOrWhiteSpace(name)
                ? (Either<string, CustomerName>) Left("invalid name")
                : Right(new CustomerName(name));
    }
}