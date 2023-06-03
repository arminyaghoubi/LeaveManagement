using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetDetails;

public class GetLeaveRequestDetailsDto
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public GetLeaveTypesDto? LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime RequestDate { get; set; }
    public string? Comment { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
}