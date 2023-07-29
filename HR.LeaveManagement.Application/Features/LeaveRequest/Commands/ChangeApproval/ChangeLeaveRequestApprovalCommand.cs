using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeApproval;

public class ChangeLeaveRequestApprovalCommand : IRequest<Unit>
{
    public required int Id { get; set; }
    public required bool Approved { get; set; }
}