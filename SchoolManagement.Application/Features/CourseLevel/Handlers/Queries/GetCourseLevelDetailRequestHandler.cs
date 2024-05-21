using AutoMapper;
using SchoolManagement.Application.DTOs.CourseLevel;
using SchoolManagement.Application.Features.CourseLevels.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseLevels.Handlers.Queries
{
    public class GetCourseLevelDetailRequestHandler : IRequestHandler<GetCourseLevelDetailRequest, CourseLevelDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<CourseLevel> _CourseLevelRepository;
        public GetCourseLevelDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseLevel> CourseLevelRepository, IMapper mapper)
        {
            _CourseLevelRepository = CourseLevelRepository;
            _mapper = mapper;
        }
        public async Task<CourseLevelDto> Handle(GetCourseLevelDetailRequest request, CancellationToken cancellationToken)
        {
            var CourseLevel = await _CourseLevelRepository.Get(request.CourseLevelId);
            return _mapper.Map<CourseLevelDto>(CourseLevel);
        }
    }
}
