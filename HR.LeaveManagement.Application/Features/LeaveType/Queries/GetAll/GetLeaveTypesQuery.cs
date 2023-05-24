using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;

public record GetLeaveTypesQuery(int Page, int PageSize) : IRequest<IEnumerable<GetLeaveTypesDto>>;
