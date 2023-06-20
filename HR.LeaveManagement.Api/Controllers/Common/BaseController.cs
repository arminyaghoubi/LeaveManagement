using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers.Common;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseController : Controller
{
}
