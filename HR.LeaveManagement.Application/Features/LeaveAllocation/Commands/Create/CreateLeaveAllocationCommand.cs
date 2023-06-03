using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Create;

public class CreateLeaveAllocationCommand : IRequest<int>
{
    public int LeaveTypeId { get; set; }
}