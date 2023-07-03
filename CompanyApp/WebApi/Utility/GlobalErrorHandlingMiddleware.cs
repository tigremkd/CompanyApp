using Azure;
using Newtonsoft.Json;
using System.Net;
using WebApi.Utility.Exceptions;

namespace WebApi.Utility
{
    public class GlobalErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _logger = logger;

        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {

                //_logger.LogError(e, e.Message);

                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {


            HttpStatusCode status;

            var stackTrace = string.Empty;
            string message;

            var exceptionType = exception.GetType();


            if (exceptionType == typeof(InnerException))
            {
                message = exception.Message;
                if (exception.InnerException != null)
                {
                    message = exception.InnerException.Message;
                }

            }
            if (exceptionType == typeof(BadRequestException))
            {
                message = exception.Message;
                status = HttpStatusCode.BadRequest;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
                stackTrace = exception.StackTrace;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = "Something went wrong... Contact the administrator";
                stackTrace = exception.StackTrace;
            }
            var response = new
            {
                message = exception.Message != null ? message : exception?.InnerException?.Message,
                stackTrace,
                status,
            };

            var exceptionResult = JsonConvert.SerializeObject(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            await context.Response.WriteAsync(exceptionResult);
        }


    }
}

