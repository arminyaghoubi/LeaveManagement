using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.ViewModels;

namespace HR.LeaveManagement.BlazorUI.Contracts;

public interface ILeaveTypeService
{
    Task<List<LeaveTypeViewModel>> GetAllAsync(int? page, int? pageSize, CancellationToken cancellation);

    Task<LeaveTypeViewModel> GetByIdAsync(int id, CancellationToken cancellation);

    Task<Response<Guid>> CreateAsync(LeaveTypeViewModel leaveType, CancellationToken cancellation);

    Task<Response<Guid>> UpdateAsync(LeaveTypeViewModel leaveType, CancellationToken cancellation);

    Task<Response<Guid>> DeleteAsync(int id, CancellationToken cancellation);
}