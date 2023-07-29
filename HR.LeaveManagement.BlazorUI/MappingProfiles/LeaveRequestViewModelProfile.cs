using AutoMapper;
using HR.LeaveManagement.BlazorUI.Services.Base;
using HR.LeaveManagement.BlazorUI.ViewModels;

namespace HR.LeaveManagement.BlazorUI.MappingProfiles;

public class LeaveRequestViewModelProfile : Profile
{
    public LeaveRequestViewModelProfile()
    {
        CreateMap<GetLeaveRequestDto, LeaveRequestViewModel>()
            .ForMember(l => l.EndDate, l => l.MapFrom(m => m.EndDate.DateTime))
            .ForMember(l => l.StartDate, l => l.MapFrom(m => m.StartDate.DateTime))
            .ForMember(l => l.RequestDate, l => l.MapFrom(m => m.StartDate.DateTime));

        CreateMap<GetLeaveRequestDetailsDto, LeaveRequestViewModel>()
            .ForMember(l => l.EndDate, l => l.MapFrom(m => m.EndDate.DateTime))
            .ForMember(l => l.StartDate, l => l.MapFrom(m => m.StartDate.DateTime))
            .ForMember(l => l.RequestDate, l => l.MapFrom(m => m.StartDate.DateTime));

        CreateMap<CreateLeaveRequestCommand, LeaveRequestViewModel>().ReverseMap();

        CreateMap<Employee, EmployeeViewModel>();
    }
}
