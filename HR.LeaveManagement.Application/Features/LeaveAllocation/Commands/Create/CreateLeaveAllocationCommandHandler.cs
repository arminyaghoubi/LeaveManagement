using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Create;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveAllocation> _leaveAllocationRepository;
    private readonly IGenericRepository<Domain.LeaveType> _leaveTypeRepository;
    private readonly IUserService _userService;

    public CreateLeaveAllocationCommandHandler(IMapper mapper,
        IGenericRepository<Domain.LeaveAllocation> leaveAllocationRepository,
        IGenericRepository<Domain.LeaveType> leaveTypeRepository,
        IUserService userService)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _userService = userService;
    }

    public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        CreateLeaveAllocationCommandValidation validation = new(_leaveTypeRepository);
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request.", validationResult);

        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

        var employees = await _userService.GetEmployeesAsync();

        var period = DateTime.Now.Year;

        foreach (var employee in employees)
        {
            if (!await AllocationExistAsync(employee.Id))
            {
                var newLeaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);
                newLeaveAllocation.EmployeeId = employee.Id;
                newLeaveAllocation.Period = period;
                newLeaveAllocation.NumberOfDays = leaveType.DefaultDays;
                await _leaveAllocationRepository.CreateAsync(newLeaveAllocation, cancellationToken);
            }
        }

        async Task<bool> AllocationExistAsync(string empolyeeId) =>
            await _leaveAllocationRepository.AnyAsync(l => l.EmployeeId == empolyeeId && l.LeaveTypeId == leaveType.Id && l.Period == period, cancellationToken);

        return Unit.Value;
    }
}