using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAll;
using HR.LeaveManagement.Application.MappingProfiles;
using HR.LeaveManagement.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.UnitTest.Features.LeaveType.Queries;

public class GetLeaveTypesQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IGenericRepository<Domain.LeaveType>> _repository;
    private readonly Mock<IApplicationLogger<GetLeaveTypesQueryHandler>> _logger;

    public GetLeaveTypesQueryHandlerTests()
    {
        var mapperConfig = new MapperConfiguration(config => config.AddProfile<LeaveTypeProfile>());

        _mapper = mapperConfig.CreateMapper();

        _logger = new Mock<IApplicationLogger<GetLeaveTypesQueryHandler>>();

        _repository = MockLeaveTypeRepository.GetLeaveTypes();
    }

    [Fact]
    public async Task Get_leave_type_list_test()
    {
        var handler = new GetLeaveTypesQueryHandler(_mapper, _repository.Object, _logger.Object);

        var result= await handler.Handle(new GetLeaveTypesQuery (1,20),CancellationToken.None);

        result.ShouldBeOfType<List<GetLeaveTypesDto>>();
        result.Count().ShouldBe(3);
    }
}
