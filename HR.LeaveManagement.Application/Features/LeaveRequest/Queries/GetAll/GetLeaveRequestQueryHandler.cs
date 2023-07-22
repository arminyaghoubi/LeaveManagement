using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAll;

public class GetLeaveRequestQueryHandler : IRequestHandler<GetLeaveRequestQuery, IEnumerable<GetLeaveRequestDto>>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveRequest> _repository;
    private readonly IUserService _userService;

    public GetLeaveRequestQueryHandler(IMapper mapper,
        IGenericRepository<Domain.LeaveRequest> repository,
        IUserService userService)
    {
        _mapper = mapper;
        _repository = repository;
        _userService = userService;
    }

    public async Task<IEnumerable<GetLeaveRequestDto>> Handle(GetLeaveRequestQuery request, CancellationToken cancellationToken)
    {
        var leaveRequests = await _repository.GetAsync(include: r => r.LeaveType, page: request.Page, pageSize: request.PageSize, cancellation: cancellationToken);

        var result = _mapper.Map<IEnumerable<GetLeaveRequestDto>>(leaveRequests);

        foreach (var item in result)
        {
            item.Employee = await _userService.GetEmployeeAsync(item.EmployeeId);
        }

        return result;
    }
}