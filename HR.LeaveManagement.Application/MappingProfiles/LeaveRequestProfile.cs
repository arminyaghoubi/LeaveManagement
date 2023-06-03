using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAll;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetDetails;

namespace HR.LeaveManagement.Application.MappingProfiles;

public class LeaveRequestProfile : Profile
{
    public LeaveRequestProfile()
    {
        CreateMap<Domain.LeaveRequest, GetLeaveRequestDto>().ReverseMap();
        CreateMap<Domain.LeaveRequest, GetLeaveRequestDetailsDto>();
    }
}
