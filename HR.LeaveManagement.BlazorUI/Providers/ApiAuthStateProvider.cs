using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HR.LeaveManagement.BlazorUI.Providers;

public class ApiAuthStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorageService;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

    public ApiAuthStateProvider(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
        _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        var isToeknPresent = await _localStorageService.ContainKeyAsync("AccessToken");
        if (!isToeknPresent)
            return new AuthenticationState(user);

        var savedToken = await _localStorageService.GetItemAsStringAsync("AccessToken");
        var tokenCotent = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);

        if (tokenCotent.ValidTo < DateTime.Now)
        {
            await _localStorageService.RemoveItemAsync("AccessToken");
            return new AuthenticationState(user);
        }

        var claims = await GetClaimsAsync();
        user = new ClaimsPrincipal(new ClaimsIdentity(claims, "JWT"));

        return new AuthenticationState(user);
    }

    public async Task LoggedInAsync()
    {
        var claims = await GetClaimsAsync();
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "JWT"));
        var authState = new AuthenticationState(user);
        NotifyAuthenticationStateChanged(Task.FromResult(authState));
    }

    public async Task LoggedOutAsync()
    {
        await _localStorageService.RemoveItemAsync("AccessToken");
        var nobody = new ClaimsPrincipal(new ClaimsIdentity());
        var userState = new AuthenticationState(nobody);
        NotifyAuthenticationStateChanged(Task.FromResult(userState));
    }

    private async Task<List<Claim>> GetClaimsAsync()
    {
        var token = await _localStorageService.GetItemAsStringAsync("AccessToken");
        var jwtSecurityToken = _jwtSecurityTokenHandler.ReadJwtToken(token);
        return jwtSecurityToken.Claims.ToList();
    }
}
