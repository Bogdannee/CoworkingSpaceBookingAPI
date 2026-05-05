using System.Net;

namespace CoworkingSpaceBookingAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public class ErrorResponse { public string Message { get; set; } }

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла непредвиденная ошибка");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                KeyNotFoundException => HttpStatusCode.NotFound,        // 404
                UnauthorizedAccessException => HttpStatusCode.Unauthorized, // 401
                InvalidOperationException => HttpStatusCode.BadRequest, // 400
                _ => HttpStatusCode.InternalServerError                 // 500
            };

            context.Response.StatusCode = (int)statusCode;

            var response = new ErrorResponse { Message = exception.Message };
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
