using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetDetails;

public record GetLeaveAllocationDetailsQuery(int Id) : IRequest<GetLeaveAllocationDetailsDto>;
