namespace HR.LeaveManagement.BlazorUI.Services.Base;

public class BaseHttpService
{
    protected IClient _client;

    public BaseHttpService(IClient client)
    {
        _client = client;
    }

    protected Response<Guid> ConvertExceptionToResponse(ApiException exception)
    {
        if (exception.StatusCode == 400)
        {
            return new Response<Guid>
            {
                Success = false,
                Message = exception.Message,
                ValidationErrors = exception.Response
            };
        }
        else if (exception.StatusCode == 404)
        {
            return new Response<Guid>
            {
                Success = false,
                Message = exception.Message,
                ValidationErrors = exception.Response
            };
        }

        return new Response<Guid>
        {
            Success = false,
            Message = "Somthing went wrong.",
        };
    }
}
