using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Localization;

namespace MaintenanceApi.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IStringLocalizer<MessageResources> localizer)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = error switch
                {
                    ArgumentException => (int)HttpStatusCode.BadRequest,
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                var result = JsonSerializer.Serialize(new
                {
                    type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    title = localizer["Error_GenericTitle"],
                    status = context.Response.StatusCode,
                    detail = error.Message
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
