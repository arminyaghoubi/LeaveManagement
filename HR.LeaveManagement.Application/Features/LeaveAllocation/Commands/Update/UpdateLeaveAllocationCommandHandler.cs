using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Update;

public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveAllocation> _leaveAllocationRepository;
    private readonly IGenericRepository<Domain.LeaveType> _leaveTypeRepository;

    public UpdateLeaveAllocationCommandHandler(IMapper mapper,
        IGenericRepository<Domain.LeaveAllocation> leaveAllocationRepository,
        IGenericRepository<Domain.LeaveType> leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        UpdateLeaveAllocationCommandValidation validation = new(_leaveAllocationRepository, _leaveTypeRepository);
        var validationResult = await validation.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request", validationResult);

        var updateLeaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);

        await _leaveAllocationRepository.UpdateAsync(updateLeaveAllocation, cancellationToken);

        return Unit.Value;
    }
}
