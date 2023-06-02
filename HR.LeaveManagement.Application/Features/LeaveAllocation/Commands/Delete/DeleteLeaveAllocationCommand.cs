using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Delete;

public class DeleteLeaveAllocationCommand : IRequest<Unit>
{
    public int Id { get; set; }
}