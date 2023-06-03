using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAll;

public record GetLeaveRequestQuery(int Page, int PageSize) : IRequest<IEnumerable<GetLeaveRequestDto>>;
