using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Arta.Api.Controllers
{
    public class BaseController : Controller
    {
        [NonAction]
        public virtual IActionResult CustomOk()
        {
            var result = new Result
            {
                Description = "",
                Status = HttpStatusCode.OK,
            };
            return new OkObjectResult(result);
        }

        [NonAction]
        public IActionResult CustomBadRequest()
        {
            var result = new Result<object>
            {
                Description = "",
                Status = HttpStatusCode.OK,
            };
            return new OkObjectResult(result);
        }


        [NonAction]
        protected static IActionResult CustomOk<T>(T data)
        {
            var result = new Result<T>
            {
                Data = data,
                Description = "",
                Status = HttpStatusCode.OK
            };

            return new OkObjectResult(result);
        }
    }
}
