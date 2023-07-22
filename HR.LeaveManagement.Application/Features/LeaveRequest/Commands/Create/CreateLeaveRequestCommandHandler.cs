using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Create;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly IApplicationLogger<CreateLeaveRequestCommandHandler> _logger;
    private readonly IGenericRepository<Domain.LeaveRequest> _leaveRequestRepository;
    private readonly IGenericRepository<Domain.LeaveAllocation> _leaveAllocationRepository;
    private readonly IGenericRepository<Domain.LeaveType> _leaveTypeRepository;
    private readonly IUserService _userService;

    public CreateLeaveRequestCommandHandler(IMapper mapper,
        IGenericRepository<Domain.LeaveRequest> leaveRequestRepository,
        IGenericRepository<Domain.LeaveType> leaveTypeRepository,
        IGenericRepository<Domain.LeaveAllocation> leaveAllocationRepository,
        IEmailSender emailSender,
        IApplicationLogger<CreateLeaveRequestCommandHandler> logger,
        IUserService userService)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _leaveAllocationRepository = leaveAllocationRepository;
        _emailSender = emailSender;
        _logger = logger;
        _userService = userService;
    }

    public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        CreateLeaveRequestCommandValidation validation = new(_leaveTypeRepository);
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request", validationResult);

        var employeeId = _userService.UserId;

        var allocation = (await _leaveAllocationRepository.GetAsync(l => l.EmployeeId == employeeId && l.LeaveTypeId == request.LeaveTypeId)).FirstOrDefault();

        if (allocation is null)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.LeaveTypeId), "You don't have any allocation."));

            throw new BadRequestException("Invalid Request", validationResult);
        }

        var daysRequested = (int)(request.EndDate - request.StartDate).TotalDays;

        if (daysRequested > allocation.NumberOfDays)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.EndDate), "You don't have enough days for this request."));

            throw new BadRequestException("Invalid Request", validationResult);
        }

        var newLeaveRequest = _mapper.Map<Domain.LeaveRequest>(request);

        newLeaveRequest.EmployeeId = employeeId;
        newLeaveRequest.RequestDate = DateTime.Now;

        await _leaveRequestRepository.CreateAsync(newLeaveRequest, cancellationToken);

        try
        {
            await _emailSender.SendAsync(
                new Models.Email.EmailMessage
                {
                    To = "Employee Email",
                    Body = "Your leave request has been created successfully.",
                    Subject = "Leave Request"
                });
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
        }

        return newLeaveRequest.Id;
    }
}
