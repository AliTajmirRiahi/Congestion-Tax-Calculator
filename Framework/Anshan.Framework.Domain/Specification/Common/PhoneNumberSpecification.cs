using PhoneNumbers;

namespace Anshan.Framework.Domain.Specification.Common
{
    public class PhoneNumberSpecification : CompositeSpecification<string>
    {
        public override bool IsSatisfiedBy(string candidate)
        {
            if (string.IsNullOrEmpty(candidate))
                return false;

            var phoneUtil = PhoneNumberUtil.GetInstance();
            var iranNumberProto = phoneUtil.Parse(candidate, "IR");
            var isValid = phoneUtil.IsValidNumber(iranNumberProto);

            return isValid;
        }
    }
}