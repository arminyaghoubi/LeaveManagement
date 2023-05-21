namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetDetails;

public class LeaveTypeDetailsDto
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
