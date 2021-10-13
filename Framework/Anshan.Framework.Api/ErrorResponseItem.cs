namespace Anshan.Framework.Api
{
    public class ErrorResponseItem
    {
        public string Message { get; set; }

        public ErrorCode Code { get; set; }

        public ErrorResponseItem(string message, ErrorCode code)
        {
            Message = message;
            Code = code;
        }
    }
}