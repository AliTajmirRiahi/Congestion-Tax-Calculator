using System;

namespace Anshan.Framework.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string code, string message) : base(message)
        {
            Code = code;
        }

        public DomainException(string message) : base(message)
        {
        }

        public string Code { get; }
    }
}