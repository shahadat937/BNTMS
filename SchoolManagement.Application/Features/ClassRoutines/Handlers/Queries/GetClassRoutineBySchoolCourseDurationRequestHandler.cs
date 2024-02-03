using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Domain;
using System.Data;
using SchoolManagement.Application.DTOs.ClassRoutine;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetClassRoutineBySchoolCourseDurationRequestHandler : IRequestHandler<GetClassRoutineBySchoolCourseDurationRequest, List<ClassRoutineDto>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _ClassRoutineRepository;

        private readonly IMapper _mapper;
        public GetClassRoutineBySchoolCourseDurationRequestHandler(ISchoolManagementRepository<ClassRoutine> ClassRoutineRepository, IMapper mapper)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
            _mapper = mapper;
        }

        public async Task<List<ClassRoutineDto>> Handle(GetClassRoutineBySchoolCourseDurationRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> ClassRoutines = _ClassRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId, "ClassPeriod", "BaseSchoolName", "CourseName", "CourseDuration", "BnaSubjectName", "ClassType", "CourseModule").OrderBy(x => x.ClassPeriod.MenuPosition);
            //var ClassRoutines = _ClassRoutineRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.ClassRoutineId);

            var ClassRoutineDtos = _mapper.Map<List<ClassRoutineDto>>(ClassRoutines);

            return ClassRoutineDtos;
        }

    }
}
