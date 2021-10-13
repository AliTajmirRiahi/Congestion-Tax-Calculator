using Anshan.Framework.Domain.Exceptions;

namespace Anshan.Framework.Domain
{
    public static class DomainValidatorExtensions
    {
        public static void Validate(this IDomainValidator validator)
        {
            if (!validator.IsValid)
                throw new ValidationFailedException();
        }
    }
}