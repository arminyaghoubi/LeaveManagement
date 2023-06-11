using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Common;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Update;

public class UpdateLeaveRequestCommand : BaseLeaveRequestDto, IRequest<Unit>
{
    public int Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public bool Cancelled { get; set; }
}