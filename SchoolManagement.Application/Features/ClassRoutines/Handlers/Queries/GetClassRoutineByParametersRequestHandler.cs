using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Domain;
using System.Data;
using SchoolManagement.Application.DTOs.ClassRoutine;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetClassRoutineByParametersRequestHandler : IRequestHandler<GetClassRoutineByParametersRequest, object>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _ClassRoutineRepository;

        private readonly IMapper _mapper;
        public GetClassRoutineByParametersRequestHandler(ISchoolManagementRepository<ClassRoutine> ClassRoutineRepository, IMapper mapper)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetClassRoutineByParametersRequest request, CancellationToken cancellationToken)
        {
            // IQueryable<ClassRoutine> ClassRoutines = _ClassRoutineRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.BnaSubjectNameId == request.BnaSubjectNameId, "ClassPeriod", "BaseSchoolName", "CourseName", "CourseDuration", "BnaSubjectName", "ClassType", "CourseModule").OrderByDescending(x => x.ClassRoutineId);
            //var ClassRoutines = _ClassRoutineRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.ClassRoutineId);

            //var ClassRoutineDtos = _mapper.Map<List<ClassRoutineDto>>(ClassRoutines);

            //return ClassRoutineDtos;

            var spQuery = String.Format("exec [spGetClassRoutineByParametersRequestforGroupByDate] '{0}',{1}, {2}", request.BaseSchoolNameId, request.CourseNameId, request.BnaSubjectNameId);

            DataTable dataTable = _ClassRoutineRepository.ExecWithSqlQuery(spQuery);

            return dataTable;
        }

    }
}
