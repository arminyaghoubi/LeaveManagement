using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Update;

public class UpdateLeaveRequestCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public bool Cancelled { get; set; }
}