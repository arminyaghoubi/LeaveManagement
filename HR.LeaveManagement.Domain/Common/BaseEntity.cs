namespace HR.LeaveManagement.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime? CreationDate { get; set; }
    public string? CreatorId { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string? ModifierId { get; set; }
}
