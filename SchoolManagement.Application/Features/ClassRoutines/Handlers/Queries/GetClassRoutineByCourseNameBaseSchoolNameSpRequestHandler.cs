using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Domain;
using System.Data;
using SchoolManagement.Application.DTOs.ClassRoutine;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{ 
    public class GetClassRoutineByCourseNameBaseSchoolNameSpRequestHandler : IRequestHandler<GetClassRoutineByCourseNameBaseSchoolNameSpRequestRequest, object>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _ClassRoutineRepository;

        private readonly IMapper _mapper;
        public GetClassRoutineByCourseNameBaseSchoolNameSpRequestHandler(ISchoolManagementRepository<ClassRoutine> ClassRoutineRepository, IMapper mapper)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetClassRoutineByCourseNameBaseSchoolNameSpRequestRequest request, CancellationToken cancellationToken)
        {
            //IQueryable<ClassRoutine> ClassRoutines = _ClassRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && (!x.Date.HasValue || x.Date.Value.Date == request.Date), "ClassPeriod", "BaseSchoolName", "CourseName", "CourseDuration", "BnaSubjectName", "ClassType", "CourseModule").OrderByDescending(x => x.ClassRoutineId);

            //var ClassRoutineDtos = _mapper.Map<List<ClassRoutineDto>>(ClassRoutines);

            //return ClassRoutineDtos;
            if(request.BaseSchoolNameId == 43) {
                var spQuery = String.Format("exec [spGetClassRoutineForNetSchool] {0},{1}, {2}", request.BaseSchoolNameId, request.CourseNameId, request.CourseWeekId);

                DataTable dataTable = _ClassRoutineRepository.ExecWithSqlQuery(spQuery);

                return dataTable;
            } else
            {
                var spQuery = String.Format("exec [spGetClassRoutineByBaseSchoolNameIdAndCourseNameId] {0},{1}, {2}, {3}", request.BaseSchoolNameId, request.CourseNameId, request.CourseWeekId, request.CourseSectionId);

                DataTable dataTable = _ClassRoutineRepository.ExecWithSqlQuery(spQuery);

                return dataTable;
            }
            
        }

    }
}
