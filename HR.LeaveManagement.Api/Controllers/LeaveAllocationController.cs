using HR.LeaveManagement.Api.Controllers.Common;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;

public class LeaveAllocationController : BaseController
{
    private readonly IMediator _mediator;

    public LeaveAllocationController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetLeaveAllocationDto>>> GetAsync(int page = 1, int pageSize = 10, CancellationToken cancellation=default) =>
        Ok(await _mediator.Send(new GetLeaveAllocationQuery(page, pageSize), cancellation));
}
