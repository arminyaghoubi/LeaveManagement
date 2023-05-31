using HR.LeaveManagement.Api.Controllers.Common;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.Create;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.Delete;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.Update;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace HR.LeaveManagement.Api.Controllers;

public class LeaveTypeController : BaseController
{
    private readonly IMediator _mediator;

    public LeaveTypeController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetLeaveTypesDto>>> GetAsync([FromQuery] int Page = 1, [FromQuery] int PageSize = 10, CancellationToken cancellation = default) =>
        Ok(await _mediator.Send(new GetLeaveTypesQuery(Page, PageSize), cancellation));

    [HttpGet("{id}")]
    public async Task<ActionResult<GetLeaveTypeDetailsDto>> GetAsync(int id, CancellationToken cancellation) =>
        Ok(await _mediator.Send(new GetLeaveTypeDetailsQuery(id), cancellation));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> PostAsync([FromBody] CreateLeaveTypeCommand leaveType, CancellationToken cancellation)
    {
        var result = await _mediator.Send(leaveType, cancellation);
        return CreatedAtAction(nameof(GetAsync), new { id = result });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> PutAsync(UpdateLeaveTypeCommand leaveType, CancellationToken cancellation)
    {
        await _mediator.Send(leaveType, cancellation);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteAsync(int id, CancellationToken cancellation)
    {
        await _mediator.Send(new DeleteLeaveTypeCommand { Id = id }, cancellation);
        return NoContent();
    }
}