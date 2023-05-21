using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetDetails;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDetailsDto>();
    }
}
