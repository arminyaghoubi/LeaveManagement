using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.Create;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Domain.LeaveAllocation> _leaveAllocationRepository;
    private readonly IGenericRepository<Domain.LeaveType> _leaveTypeRepository;

    public CreateLeaveAllocationCommandHandler(IMapper mapper,
        IGenericRepository<Domain.LeaveAllocation> leaveAllocationRepository,
        IGenericRepository<Domain.LeaveType> leaveTypeRepository)
    {
        _mapper = mapper;
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        CreateLeaveAllocationCommandValidation validation = new(_leaveTypeRepository);
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request.", validationResult);

        var newLeaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);

        await _leaveAllocationRepository.CreateAsync(newLeaveAllocation, cancellationToken);

        return newLeaveAllocation.Id;
    }
}