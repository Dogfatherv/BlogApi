using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.MIddleware
{
    public class GlobalExceptionalHandler : IExceptionHandler

    {
        private readonly ILogger<GlobalExceptionalHandler> _logger;
        public GlobalExceptionalHandler(ILogger<GlobalExceptionalHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpcontext,
            Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An unexpected error occured.");

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An unexpected error occured.",
                Detail = "Please try again later."
            };

            httpcontext.Response.StatusCode =
                StatusCodes.Status500InternalServerError;

            await httpcontext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
            
         
    }
}
