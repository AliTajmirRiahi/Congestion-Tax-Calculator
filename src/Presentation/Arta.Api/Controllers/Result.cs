using System.Net;

namespace Arta.Api.Controllers
{
    public class Result<T>
    {
        public HttpStatusCode Status { get; set; }
        public string Description { get; set; }
        public T Data { get; set; }
    }

    public class Result
    {
        public HttpStatusCode Status { get; set; }
        public string Description { get; set; }
    }
}
