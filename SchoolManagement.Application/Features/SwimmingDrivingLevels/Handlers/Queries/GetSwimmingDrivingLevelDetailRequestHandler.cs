using AutoMapper;
using SchoolManagement.Application.DTOs.SwimmingDrivingLevel;
using SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SwimmingDrivingLevels.Handlers.Queries
{
    public class GetSwimmingDrivingLevelDetailRequestHandler : IRequestHandler<GetSwimmingDrivingLevelDetailRequest, SwimmingDrivingLevelDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SwimmingDrivingLevel> _SwimmingDrivingLevelRepository;
        public GetSwimmingDrivingLevelDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.SwimmingDrivingLevel> SwimmingDrivingLevelRepository, IMapper mapper)
        {
            _SwimmingDrivingLevelRepository = SwimmingDrivingLevelRepository;
            _mapper = mapper;
        }
        public async Task<SwimmingDrivingLevelDto> Handle(GetSwimmingDrivingLevelDetailRequest request, CancellationToken cancellationToken)
        {
            var SwimmingDrivingLevel = await _SwimmingDrivingLevelRepository.Get(request.SwimmingDrivingLevelId);
            return _mapper.Map<SwimmingDrivingLevelDto>(SwimmingDrivingLevel);
        }
    }
}
