using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.RoutineNotes.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.RoutineNotes.Handlers.Queries
{
    public class GetRoutineNotesForDashboardSpRequestHandler : IRequestHandler<GetRoutineNotesForDashboardSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetRoutineNotesForDashboardSpRequestHandler(ISchoolManagementRepository<ClassRoutine> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetRoutineNotesForDashboardSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetRoutineNotesForDashboard] '{0}', {1}, {2}, {3}", request.Current, request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
