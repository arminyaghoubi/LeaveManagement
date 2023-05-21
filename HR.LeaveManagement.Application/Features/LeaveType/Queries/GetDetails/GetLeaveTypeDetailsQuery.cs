using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetDetails;

public record GetLeaveTypeDetailsQuery(int Id) : IRequest<GetLeaveTypeDetailsDto>;