using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseDurationDetailRequestHandler : IRequestHandler<GetCourseDurationDetailRequest, CourseDurationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;
        public GetCourseDurationDetailRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
        }
        public async Task<CourseDurationDto> Handle(GetCourseDurationDetailRequest request, CancellationToken cancellationToken)
        {
            //var CourseDuration = _CourseDurationRepository.FinedOneInclude(x =>x.CourseDurationId == request.CourseDurationId, "BaseSchoolName");
            var CourseDuration = _CourseDurationRepository.FinedOneInclude(x => x.CourseDurationId == request.CourseDurationId, "CourseName", "BaseSchoolName", "OrganizationName");
            return _mapper.Map<CourseDurationDto>(CourseDuration);
        }
    }
}
