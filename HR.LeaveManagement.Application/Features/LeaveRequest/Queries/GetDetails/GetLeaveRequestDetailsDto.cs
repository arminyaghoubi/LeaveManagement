using HR.LeaveManagement.Application.Features.LeaveRequest.Commands.Common;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetDetails;

public class GetLeaveRequestDetailsDto: BaseLeaveRequestDto
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public GetLeaveTypesDto? LeaveType { get; set; }
    public DateTime RequestDate { get; set; }
    public string? Comment { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
}