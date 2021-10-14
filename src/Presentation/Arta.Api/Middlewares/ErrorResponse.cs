using System.Collections.Generic;
using System.Net;

namespace Arta.Api.Middlewares
{
    public class ErrorResponse
    {
        public ErrorResponse(string message, HttpStatusCode code, List<ErrorResponseItem> details)
        {
            Message = message;
            Code = code;
            Details = details;
        }

        public ErrorResponse(string message, HttpStatusCode code)
        {
            Message = message;
            Code = code;
        }

        public string Message { get; }

        public HttpStatusCode Code { get; }

        public List<ErrorResponseItem> Details { get; }

        public static ErrorResponse Create(string message, HttpStatusCode code)
        {
            var response = new ErrorResponse(message, code);
            return response;
        }
    }
}