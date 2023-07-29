using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.ViewModels;

namespace HR.LeaveManagement.BlazorUI.Contracts;

public interface ILeaveRequestService
{
    Task<List<LeaveRequestViewModel>> GetAllAsync(int? page, int? pageSize, CancellationToken cancellation);

    Task<LeaveRequestViewModel> GetByIdAsync(int id, CancellationToken cancellation);

    Task<Response<Guid>> CreateAsync(LeaveRequestViewModel leaveRequest, CancellationToken cancellation);

    ReportLeaveRequestViewModel GetReportLeaveRequest(IEnumerable<LeaveRequestViewModel> leaveRequest);

    Task<Response<Guid>> ChangeApprovalAsync(int id, bool approved, CancellationToken cancellation);
}