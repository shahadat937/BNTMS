using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.RoutineNotes.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.RoutineNotes.Handlers.Queries
{
    public class GetRoutineNotesForRoutineSpRequestHandler : IRequestHandler<GetRoutineNotesForRoutineSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetRoutineNotesForRoutineSpRequestHandler(ISchoolManagementRepository<ClassRoutine> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetRoutineNotesForRoutineSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetRoutineNotesForRoutine] {0}, {1}, {2}, {3}", request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId, request.CourseWeekId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
