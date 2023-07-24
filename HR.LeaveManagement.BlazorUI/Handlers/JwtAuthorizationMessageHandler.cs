

using Blazored.LocalStorage;

namespace HR.LeaveManagement.BlazorUI.Handlers;

public class JwtAuthorizationMessageHandler : DelegatingHandler
{
    private readonly ILocalStorageService _localStorageService;

    public JwtAuthorizationMessageHandler(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _localStorageService.GetItemAsStringAsync("AccessToken");
        request.Headers.Clear();
        request.Headers.Add("Authorization", $"Bearer {token}");
        return await base.SendAsync(request, cancellationToken);
    }
}
