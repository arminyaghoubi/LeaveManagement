using HR.LeaveManagement.Api.Controllers.Common;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<ActionResult<AuthResponse>> LoginAsync(AuthRequest request) => 
        Ok(await _service.LoginAsync(request));

    [AllowAnonymous]
    [HttpPost("Registration")]
    public async Task<ActionResult<RegistrationResponse>> RegistrationAsync(RegistrationRequest request) => 
        Ok(await _service.RegisterAsync(request));
}