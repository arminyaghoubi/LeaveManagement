using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Providers;
using HR.LeaveManagement.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace HR.LeaveManagement.BlazorUI.Services;

public class AuthService : BaseHttpService, IAuthService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthService(IClient client,
        ILocalStorageService localStorageService,
        AuthenticationStateProvider authenticationStateProvider) : base(client, localStorageService)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        try
        {
            var result = await _client.LoginAsync(new AuthRequest { Email = email, Password = password });

            if (string.IsNullOrEmpty(result.AccessToken))
                return false;
            
            await _localStorageService.SetItemAsStringAsync("AccessToken", result.AccessToken);
            await ((ApiAuthStateProvider)_authenticationStateProvider).LoggedInAsync();

            return true;
        }
        catch (ApiException)
        {
            return false;
        }
    }

    public async Task Logout()
    {
        await ((ApiAuthStateProvider)_authenticationStateProvider).LoggedOutAsync();
    }

    public async Task<bool> RegisterAsync(string firstName, string lastName, string email, string password)
    {
        var result = await _client.RegistrationAsync(
            new RegistrationRequest
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            });
        return !string.IsNullOrEmpty(result.Id);
    }
}