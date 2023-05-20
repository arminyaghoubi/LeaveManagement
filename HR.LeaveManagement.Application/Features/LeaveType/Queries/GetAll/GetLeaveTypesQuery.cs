using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;

public record GetLeaveTypesQuery(int page, int pageSize) : IRequest<IEnumerable<LeaveTypeDto>>;
