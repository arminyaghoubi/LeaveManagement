using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.Create;

public class CreateLeaveTypeCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}