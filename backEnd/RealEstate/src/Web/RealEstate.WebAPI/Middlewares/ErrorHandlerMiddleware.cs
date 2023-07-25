using System.Net;

namespace RealEstate.WebAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private static ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await HandleExceptionAsync(ex);
            }
        }
        private static Task HandleExceptionAsync(Exception ex)
        {
            _logger.LogError($"{DateTime.Now.ToString("HH:mm:ss")} : {ex}");
            return Task.CompletedTask;
        }
    }
}

