using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookLibraryAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unexpected error occurred.");

            var statusCode = HttpStatusCode.InternalServerError;
            string errorTitle = "An unexpected error occured";
            string? errorDetail = exception.Message;

            if (exception is ArgumentNullException)
            {
                statusCode = HttpStatusCode.BadRequest;
                errorTitle = "Invalid request.";
            }
            else if (exception is KeyNotFoundException) 
            {
                statusCode = HttpStatusCode.NotFound;
                errorTitle = "The requested book could not be found.";
            }

            if (!context.Response.HasStarted)
            {
                context.Response.Clear();
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";

                var problemDetails = new ProblemDetails
                {
                    Status = (int)statusCode,
                    Title = errorTitle,
                    Detail = errorDetail,
                    Instance = context.Request.Path,
                    Type = "about:blank"
                };

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
