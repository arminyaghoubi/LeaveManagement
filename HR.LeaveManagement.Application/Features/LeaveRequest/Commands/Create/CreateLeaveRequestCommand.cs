using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Common;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Create;

public class CreateLeaveRequestCommand : BaseLeaveRequestDto, IRequest<int>
{
    public string Comment { get; set; } = string.Empty;
}