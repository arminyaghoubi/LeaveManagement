namespace HR.LeaveManagement.BlazorUI.ViewModels;

public class ReportLeaveRequestViewModel
{
    public int TotalRequests { get; set; }
    public int PendingRequests { get; set; }
    public int RejectedRequests { get; set; }
    public int ApprovedRequests { get; set; }
}