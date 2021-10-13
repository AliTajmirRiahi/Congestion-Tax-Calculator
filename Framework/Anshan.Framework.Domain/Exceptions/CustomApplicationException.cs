using System;

namespace Anshan.Framework.Domain.Exceptions
{
    public class CustomApplicationException : Exception
    {
        public CustomApplicationException(string code, string message) : base(message)
        {
            Code = code;
        }

        public CustomApplicationException(string message) : base(message)
        {
        }

        public string Code { get; }
    }
}