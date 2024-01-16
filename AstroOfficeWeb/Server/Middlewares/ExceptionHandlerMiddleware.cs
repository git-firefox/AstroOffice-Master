using System.Net;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeWeb.Server.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger _logger;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            //_logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ApiErrorResponse()
            {
                Status = context.Response.StatusCode,
                Type = "Internal Server Error.",
                Title = "Internal Server Error from the custom middleware."
            }.ToStringX());
        }
    }
}
