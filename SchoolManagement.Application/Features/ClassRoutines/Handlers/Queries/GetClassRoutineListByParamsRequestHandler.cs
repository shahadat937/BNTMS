using AutoMapper;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetClassRoutineListByParamsRequestHandler : IRequestHandler<GetClassRoutineListByParamsRequest, List<ClassRoutineDto>>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _ClassRoutineRepository;

        private readonly IMapper _mapper;

        public GetClassRoutineListByParamsRequestHandler(ISchoolManagementRepository<ClassRoutine> ClassRoutineRepository, IMapper mapper)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
            _mapper = mapper;
        }

        public async Task<List<ClassRoutineDto>> Handle(GetClassRoutineListByParamsRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> ClassRoutines = _ClassRoutineRepository.FilterWithInclude(x => (x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseDurationId == request.CourseDurationId && x.CourseNameId == request.CourseNameId && x.CourseWeekId == request.CourseWeekId && x.CourseSectionId == request.CourseSectionId && x.AttendanceComplete == 0), "ClassPeriod", "BaseSchoolName", "CourseName", "CourseDuration", "BnaSubjectName", "ClassType", "CourseModule", "MarkType", "CourseWeek", "CourseSection", "Trainee");
            
            var ClassRoutineDtos = _mapper.Map<List<ClassRoutineDto>>(ClassRoutines);
            
            //var result = new List<ClassRoutineDto>(ClassRoutineDtos);

            return ClassRoutineDtos;


        }
    }
}
