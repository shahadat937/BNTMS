using AutoMapper;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries   
{
    public class GetSelectedPeriodBySchoolAndCourseRequestHandler : IRequestHandler<GetSelectedPeriodBySchoolAndCourseRequest, List<ClassPeriodDto>>
    {

        private readonly ISchoolManagementRepository<ClassPeriod> _ClassPeriodRepository;

        private readonly IMapper _mapper;

        public GetSelectedPeriodBySchoolAndCourseRequestHandler(ISchoolManagementRepository<ClassPeriod> ClassPeriodRepository, IMapper mapper)
        {
            _ClassPeriodRepository = ClassPeriodRepository;
            _mapper = mapper;
        }

        public async Task<List<ClassPeriodDto>> Handle(GetSelectedPeriodBySchoolAndCourseRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassPeriod> ClassPeriods = _ClassPeriodRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId, "BaseSchoolName", "BnaClassScheduleStatus").OrderBy(x => x.MenuPosition);
            //var ClassPeriods = _ClassPeriodRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.ClassPeriodId);

            var ClassPeriodDtos = _mapper.Map<List<ClassPeriodDto>>(ClassPeriods);

            return ClassPeriodDtos;
        }
    }
}
