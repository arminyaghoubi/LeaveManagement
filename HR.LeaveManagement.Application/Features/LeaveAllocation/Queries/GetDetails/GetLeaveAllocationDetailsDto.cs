namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetDetails;

public class GetLeaveAllocationDetailsDto
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}