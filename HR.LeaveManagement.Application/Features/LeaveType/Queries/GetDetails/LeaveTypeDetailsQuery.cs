using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetDetails;

public record LeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;