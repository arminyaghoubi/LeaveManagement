namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAll;

public class GetLeaveAllocationDto
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public int Period { get; set; }
}