using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Delete;

public record DeleteLeaveRequestCommand(int Id) : IRequest<Unit>;