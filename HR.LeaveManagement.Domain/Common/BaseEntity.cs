namespace HR.LeaveManagement.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
