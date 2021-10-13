using System.Linq;

namespace Anshan.Framework.Domain.Specification.Common
{
    public class AnyNullOrEmptySpecification : CompositeSpecification<object>
    {
        public override bool IsSatisfiedBy(object candidate)
        {
            return candidate.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => (string) pi.GetValue(candidate))
                .Any(string.IsNullOrEmpty);
        }
    }
}