using FluentValidation;
using IVCRM.BLL.Exceptions;
using System.Net;

namespace IVCRM.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ResourceNotFoundException ex)
            {
                HandleResourceException(context);
            }
            catch (ValidationException ex)
            {
                HandleValidationException(context, ex);
            }
        }

        private static void HandleResourceException(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }

        private static void HandleValidationException(HttpContext context, ValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.WriteAsJsonAsync(exception.Message);
        }
    }
}
