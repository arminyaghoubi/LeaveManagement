using HR.LeaveManagement.Api.Controllers.Common;
using MediatR;

namespace HR.LeaveManagement.Api.Controllers;

public class LeaveRequestController : BaseController
{
    private readonly IMediator _mediator;

    public LeaveRequestController(IMediator mediator)
    {
        _mediator = mediator;
    }


}    