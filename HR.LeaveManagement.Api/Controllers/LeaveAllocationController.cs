using HR.LeaveManagement.Api.Controllers.Common;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Create;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Delete;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Update;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAll;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;

public class LeaveAllocationController : BaseController
{
    private readonly IMediator _mediator;

    public LeaveAllocationController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetLeaveAllocationDto>>> GetAsync(int page = 1, int pageSize = 10, CancellationToken cancellation = default) =>
        Ok(await _mediator.Send(new GetLeaveAllocationQuery(page, pageSize), cancellation));

    [HttpGet("{id}")]
    public async Task<ActionResult<GetLeaveAllocationDetailsDto>> GetAsync(int id, CancellationToken cancellation) =>
        Ok(await _mediator.Send(new GetLeaveAllocationDetailsQuery(id), cancellation));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> PostAsync(CreateLeaveAllocationCommand leaveAllocation, CancellationToken cancellation)
    {
        var result = await _mediator.Send(leaveAllocation, cancellation);
        return CreatedAtAction(nameof(GetAsync), new { id = result });
    }

    [HttpPut]   
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> PutAsync(UpdateLeaveAllocationCommand leaveAllocation, CancellationToken cancellation)
    {
        await _mediator.Send(leaveAllocation, cancellation);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteAsync(int id, CancellationToken cancellation)
    {
        await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id }, cancellation);
        return NoContent();
    }
}
