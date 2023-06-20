using Blazored.LocalStorage;

namespace HR.LeaveManagement.BlazorUI.Services.Base;

public class BaseHttpService
{
    protected IClient _client;
    protected readonly ILocalStorageService _localStorageService;    

    public BaseHttpService(IClient client, ILocalStorageService localStorageService)
    {
        _client = client;
        _localStorageService = localStorageService;
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

    protected async Task AddBearerTokenToHeader()
    {
        var token = await _localStorageService.GetItemAsStringAsync("AccessToken");
        _client.HttpClient.DefaultRequestHeaders.Add("Bearer", token);
    }
}
