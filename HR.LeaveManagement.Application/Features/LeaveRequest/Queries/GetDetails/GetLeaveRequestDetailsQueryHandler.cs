using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetDetails;

public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailsQuery, GetLeaveRequestDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveRequest> _repository;
    private readonly IUserService _userService;

    public GetLeaveRequestDetailsQueryHandler(IMapper mapper,
        IGenericRepository<Domain.LeaveRequest> repository,
        IUserService userService)
    {
        _mapper = mapper;
        _repository = repository;
        _userService = userService;
    }

    public async Task<GetLeaveRequestDetailsDto> Handle(GetLeaveRequestDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _repository.GetByIdAsync(request.Id, include: r => r.LeaveType, cancellation: cancellationToken);

        var result = _mapper.Map<GetLeaveRequestDetailsDto>(leaveRequest);

        result.Employee = await _userService.GetEmployeeAsync(leaveRequest.EmployeeId);

        return result;
    }
}