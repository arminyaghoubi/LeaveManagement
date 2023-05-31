using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAll;

public record GetLeaveAllocationQuery(int Page, int PageSize) : IRequest<IEnumerable<GetLeaveAllocationDto>>;
