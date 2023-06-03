using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAll;

public class GetLeaveRequestDto
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public GetLeaveTypesDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime RequestDate { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
}