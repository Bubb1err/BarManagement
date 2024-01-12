using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using BarManagement.API.Models;

namespace BarManagement.API.Middlewares
{
    internal class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occurred: {Message}", ex.Message);

                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string response = JsonSerializer.Serialize(new ErrorResponse(HttpStatusCode.InternalServerError, "Error occurred"));

            await httpContext.Response.WriteAsync(response);
        }
    }
    internal static class ExceptionHandlingMiddlewareExtensions
    {
        internal static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder builder)
            => builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
