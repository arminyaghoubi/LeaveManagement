using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetDetails;

public record GetLeaveRequestDetailsQuery(int Id) : IRequest<GetLeaveRequestDetailsDto>;
