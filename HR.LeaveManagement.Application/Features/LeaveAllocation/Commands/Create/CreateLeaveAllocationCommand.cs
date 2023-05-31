using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Create;

public class CreateLeaveAllocationCommand : IRequest<int>
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}