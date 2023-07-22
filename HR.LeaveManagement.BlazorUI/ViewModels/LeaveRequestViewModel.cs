using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.BlazorUI.ViewModels;

public class LeaveRequestViewModel
{
    public int Id { get; set; }
    [Required]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; } = DateTime.Now;
    [Required]
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; } = DateTime.Now;
    public LeaveTypeViewModel? LeaveType { get; set; }
    [Required]
    [Display(Name = "Leave Type")]
    public int LeaveTypeId { get; set; }
    [Display(Name = "Date Requested")]
    public DateTime RequestDate { get; set; }
    public string? Comment { get; set; }
    [Display(Name = "Approval State")]
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public EmployeeViewModel Employee { get; set; }
}