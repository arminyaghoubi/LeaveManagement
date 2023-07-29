using HR.LeaveManagement.Api.Controllers.Common;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeApproval;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Create;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Delete;
using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Update;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAll;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;

public class LeaveRequestController : BaseController
{
    private readonly IMediator _mediator;

    public LeaveRequestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<LeaveRequestsController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetLeaveRequestDto>>> GetAsync(int page, int pageSize, CancellationToken cancellation) =>
        Ok(await _mediator.Send(new GetLeaveRequestQuery(page, pageSize), cancellation));

    // GET api/<LeaveRequestsController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetLeaveRequestDetailsDto>> GetAsync(int id, CancellationToken cancellation) =>
        Ok(await _mediator.Send(new GetLeaveRequestDetailsQuery(id), cancellation));

    // POST api/<LeaveRequestsController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> PostAsync([FromBody] CreateLeaveRequestCommand leaveRequest, CancellationToken cancellation)
    {
        var result = await _mediator.Send(leaveRequest, cancellation);
        return CreatedAtAction(nameof(GetAsync), new { id = result });
    }

    [HttpPut("ChangeApproval")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> ChangeApprovalAsync(ChangeLeaveRequestApprovalCommand leaveRequest, CancellationToken cancellation)
    {
        await _mediator.Send(leaveRequest, cancellation);
        return NoContent();
    }
}