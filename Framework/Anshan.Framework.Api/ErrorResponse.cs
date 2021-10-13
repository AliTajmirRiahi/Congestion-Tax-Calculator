using System.Collections.Generic;

namespace Anshan.Framework.Api
{
    public class ErrorResponse
    {
        public string Message { get; private set; }

        public ErrorCode Code { get; private set; }

        public List<ErrorResponseItem> Details { get; private set; }

        public ErrorResponse(string message, ErrorCode code, List<ErrorResponseItem> details)
        {
            Message = message;
            Code = code;
            Details = details;
        }

        public ErrorResponse(string message, ErrorCode code)
        {
            Message = message;
            Code = code;
        }

        public static ErrorResponse Create(string message, ErrorCode code)
        {
            var response = new ErrorResponse(message, code);
            return response;
        }
    }
}