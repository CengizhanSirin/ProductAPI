using Microsoft.AspNetCore.Diagnostics;
using ProductAPI.Application.Results;
using System.Net;

namespace ProductAPI.API.Middlewares.ExceptionHandling
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> _logger): IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            //Loglama
            _logger.LogError(exception, exception.Message);

            //Client için uygun bir hata mesajı oluşturma
            var errorAsDto = ServiceResult.Fail("An unexpected error occurred.",HttpStatusCode.InternalServerError);
     
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsJsonAsync(errorAsDto, cancellationToken);

            return true;
        }
    }
}
