namespace Arta.Api.Middlewares
{
    public class ErrorResponseItem
    {
        public ErrorResponseItem(string message, ErrorCode code)
        {
            Message = message;
            Code = code;
        }

        public string Message { get; set; }

        public ErrorCode Code { get; set; }
    }
}