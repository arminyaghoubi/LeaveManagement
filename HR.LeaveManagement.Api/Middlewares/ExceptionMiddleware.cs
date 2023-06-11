using HR.LeaveManagement.Api.Models;
using HR.LeaveManagement.Application.Exceptions;
using System.Net;

namespace HR.LeaveManagement.Api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await ExceptionHandlerAsync(context, ex);
        }
    }

    private async Task ExceptionHandlerAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        CustomValidationProblemDetails problem;

        switch (ex)
        {
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomValidationProblemDetails
                {
                    Title = badRequestException.Message,
                    Detail = badRequestException.InnerException?.Message,
                    Errors = badRequestException.ValidationErrors,
                    Type = nameof(BadRequestException),
                    Status = (int)statusCode
                };
                break;
            case NotFoundException notFoundException:
                statusCode = HttpStatusCode.NotFound;
                problem = new CustomValidationProblemDetails
                {
                    Title = notFoundException.Message,
                    Detail = notFoundException.InnerException?.Message,
                    Type = nameof(NotFoundException),
                    Status = (int)statusCode
                };
                break;
            default:
                problem = new CustomValidationProblemDetails
                {
                    Title = ex.Message,
                    Detail = ex.InnerException?.Message,
                    Type = nameof(HttpStatusCode.InternalServerError),
                    Status = (int)statusCode
                };
                break;
        }

        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsJsonAsync(problem);
    }
}
