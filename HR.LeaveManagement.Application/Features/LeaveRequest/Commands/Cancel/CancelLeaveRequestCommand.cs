using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Cancel;

public class CancelLeaveRequestCommand : IRequest<Unit>
{
    public required int Id { get; set; }
}