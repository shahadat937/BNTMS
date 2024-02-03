using AutoMapper;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetCentralExamRoutineListByParamsRequestHandler : IRequestHandler<GetCentralExamRoutineListByParamsRequest, List<ClassRoutineDto>>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _ClassRoutineRepository;

        private readonly IMapper _mapper;

        public GetCentralExamRoutineListByParamsRequestHandler(ISchoolManagementRepository<ClassRoutine> ClassRoutineRepository, IMapper mapper)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
            _mapper = mapper;
        }

        public async Task<List<ClassRoutineDto>> Handle(GetCentralExamRoutineListByParamsRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> ClassRoutines = _ClassRoutineRepository.FilterWithInclude(x => (x.CourseDurationId == request.CourseDurationId  && x.AttendanceComplete == 0), "ClassPeriod", "BaseSchoolName", "CourseName", "CourseDuration", "BnaSubjectName", "ClassType", "CourseModule", "CourseWeek", "Branch");
            
            var ClassRoutineDtos = _mapper.Map<List<ClassRoutineDto>>(ClassRoutines);
            
            //var result = new List<ClassRoutineDto>(ClassRoutineDtos);

            return ClassRoutineDtos;


        }
    }
}
