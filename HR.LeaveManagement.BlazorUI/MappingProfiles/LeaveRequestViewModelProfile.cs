using AutoMapper;
using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.ViewModels;

namespace HR.LeaveManagement.BlazorUI.MappingProfiles;

public class LeaveRequestViewModelProfile : Profile
{
    public LeaveRequestViewModelProfile()
    {
        CreateMap<GetLeaveRequestDto, LeaveRequestViewModel>();
        CreateMap<LeaveRequestViewModel, CreateLeaveRequestCommand>();
        CreateMap<Employee, EmployeeViewModel>();
    }
}
