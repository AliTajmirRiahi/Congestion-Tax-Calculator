using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Arta.Api.Config.ValidatorHandling
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;


            var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                .SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage)
                .ToList();

            var responseObj = new
            {
                Message = "Bad Request",
                Type = "validation",
                Errors = errors
            };

            context.Result = new JsonResult(responseObj)
            {
                StatusCode = 400
            };
        }
    }
}