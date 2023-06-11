namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Common;

public abstract class BaseLeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
}