using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Domain;
using System.Data;
using SchoolManagement.Application.DTOs.ClassRoutine;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{ 
    public class GetClassRoutineForSchoolDashboardSpRequestRequestHandler : IRequestHandler<GetClassRoutineForSchoolDashboardSpRequestRequest, object>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _ClassRoutineRepository;

        private readonly IMapper _mapper;
        public GetClassRoutineForSchoolDashboardSpRequestRequestHandler(ISchoolManagementRepository<ClassRoutine> ClassRoutineRepository, IMapper mapper)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetClassRoutineForSchoolDashboardSpRequestRequest request, CancellationToken cancellationToken)
        {
            //IQueryable<ClassRoutine> ClassRoutines = _ClassRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && (!x.Date.HasValue || x.Date.Value.Date == request.Date), "ClassPeriod", "BaseSchoolName", "CourseName", "CourseDuration", "BnaSubjectName", "ClassType", "CourseModule").OrderByDescending(x => x.ClassRoutineId);

            //var ClassRoutineDtos = _mapper.Map<List<ClassRoutineDto>>(ClassRoutines);

            //return ClassRoutineDtos;
            try
            {
                var spQuery = String.Format("exec [spGetClassRoutineForSchoolDashboard] '{0}',{1}, {2}, {3}", request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId, request.CourseSectionId);

                DataTable dataTable = _ClassRoutineRepository.ExecWithSqlQuery(spQuery);

                return dataTable;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

    }
}
