using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetPendingInstructorExamMarkInfoBySchoolIdSpRequestHandler : IRequestHandler<GetPendingInstructorExamMarkInfoBySchoolIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetPendingInstructorExamMarkInfoBySchoolIdSpRequestHandler(ISchoolManagementRepository<ClassRoutine> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetPendingInstructorExamMarkInfoBySchoolIdSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetInstructorPendingExamEvaluation] {0}, {1}", request.TraineeId, request.CourseDurationId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
