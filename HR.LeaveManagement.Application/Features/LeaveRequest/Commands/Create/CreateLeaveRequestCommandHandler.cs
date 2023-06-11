using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Email;
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
    private readonly IGenericRepository<Domain.LeaveType> _leaveTypeRepository;

    public CreateLeaveRequestCommandHandler(IMapper mapper, IGenericRepository<Domain.LeaveRequest> leaveRequestRepository, IGenericRepository<Domain.LeaveType> leaveTypeRepository, IEmailSender emailSender, IApplicationLogger<CreateLeaveRequestCommandHandler> logger)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _emailSender = emailSender;
        _logger = logger;
    }

    public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        CreateLeaveRequestCommandValidation validation = new(_leaveTypeRepository);
        var validationResult = await validation.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request", validationResult);

        // Get requesting employee id

        // Check on employee allocation

        // if allocation are not enough return validation error

        var newLeaveRequest = _mapper.Map<Domain.LeaveRequest>(request);

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
