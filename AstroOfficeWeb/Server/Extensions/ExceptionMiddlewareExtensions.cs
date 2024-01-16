using System.Net;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace AstroOfficeWeb.Server.Extensions
{
    public class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ApiErrorResponse()
                        {
                            Status = context.Response.StatusCode,
                            Title = "Internal Server Error."
                        }.ToStringX());
                    }
                });
            });
        }
    }
}
