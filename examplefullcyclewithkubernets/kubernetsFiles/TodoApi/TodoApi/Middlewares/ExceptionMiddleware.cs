using TodoApi.DTOs.Responses;
using TodoApi.Exceptions;

namespace TodoApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        private readonly Dictionary<Type, int> _statusCodeMap = new()
        {
            { typeof(NotFoundException), StatusCodes.Status404NotFound },
        };

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var errorResult = GetErrorResult(ex);
                context.Response.StatusCode = errorResult.StatusCode;
                await context.Response.WriteAsJsonAsync(errorResult);
            }
        }

        private ErrorDTO GetErrorResult(Exception exception)
        {
            var errorResult = new ErrorDTO()
            {
                Message = exception.Message
            };

            if (_statusCodeMap.TryGetValue(exception.GetType(), out int status))
            {
                errorResult.StatusCode = status;
            }
            else
            {
                errorResult.StatusCode = StatusCodes.Status500InternalServerError;
                errorResult.Message = "An error occurred while processing the request.";

                _logger.LogError(exception, "Unexpected error.");
            }

            return errorResult;
        }
    }
}
