namespace Anshan.Framework.Domain.Specification.Common
{
    public class NotNullOrEmptySpecification : CompositeSpecification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            return !string.IsNullOrEmpty(candidate);
        }
    }
}