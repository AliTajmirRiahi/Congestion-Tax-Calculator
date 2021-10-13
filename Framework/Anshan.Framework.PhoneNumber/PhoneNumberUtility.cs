using PhoneNumbers;

namespace Anshan.Framework.PhoneNumber
{
    public static class PhoneNumberUtility
    {
        public static string NormalizePhoneNumber(this string phoneNumber)
        {
            var phoneUtil = PhoneNumberUtil.GetInstance();
            var iranNumberProto = phoneUtil.Parse(phoneNumber, "IR");

            var normalizePhoneNumber = phoneUtil.Format(iranNumberProto, PhoneNumberFormat.E164);

            return normalizePhoneNumber;
        }
    }
}