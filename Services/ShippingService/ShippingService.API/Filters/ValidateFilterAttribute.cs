using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ShippingService.API.Filters
{
    public class ValidateFilterAttribute : ResultFilterAttribute
    {
        private const string Title = "One or more validation errors occurred.";
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);

            if (!context.ModelState.IsValid)
            {
                var entry = context.ModelState.Values.FirstOrDefault();

                var messages = entry?.Errors.Select(x => x.ErrorMessage);

                context.Result = new BadRequestObjectResult(new
                {
                    title = Title,
                    status = (int)HttpStatusCode.BadRequest,
                    messages,
                });
            }
        }
    }
}
