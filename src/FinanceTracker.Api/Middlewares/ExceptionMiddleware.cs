using FinanceTracker.Service.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinanceTracker.Api.Middlewares;

public class ExceptionMiddleware(
    RequestDelegate requestDelegate,
    ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {

        }
        catch (CustomException ex)
        {

        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Models.Response
            {
                StatusCode = 500,
                Message = ex.Message
            });
        }
    }
}
