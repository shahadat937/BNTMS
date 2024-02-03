using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetExamRoutineForStudentDashboardSpRequestHandler : IRequestHandler<GetExamRoutineForStudentDashboardSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _routineRepository;

        private readonly IMapper _mapper;

        public GetExamRoutineForStudentDashboardSpRequestHandler(ISchoolManagementRepository<ClassRoutine> routineRepository, IMapper mapper)
        {
            _routineRepository = routineRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetExamRoutineForStudentDashboardSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetExamRoutineForStudentDashboard] {0}", request.CourseDurationId);
            
            DataTable dataTable = _routineRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
