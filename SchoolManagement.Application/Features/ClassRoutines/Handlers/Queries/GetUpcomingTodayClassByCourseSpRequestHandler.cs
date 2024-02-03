using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetUpcomingTodayClassByCourseSpRequestHandler : IRequestHandler<GetUpcomingTodayClassByCourseSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _routineRepository;

        private readonly IMapper _mapper;

        public GetUpcomingTodayClassByCourseSpRequestHandler(ISchoolManagementRepository<ClassRoutine> routineRepository, IMapper mapper)
        {
            _routineRepository = routineRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetUpcomingTodayClassByCourseSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetUpcomingTodayClassByCourse] '{0}', {1}, {2},{3},{4},{5}", request.CurrentDate,request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId, request.BnaSubjectNameId, request.TraineeId);
            
            DataTable dataTable = _routineRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
