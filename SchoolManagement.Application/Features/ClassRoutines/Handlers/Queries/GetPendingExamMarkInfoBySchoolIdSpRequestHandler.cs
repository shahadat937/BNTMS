using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetPendingExamMarkInfoBySchoolIdSpRequestHandler : IRequestHandler<GetPendingExamMarkInfoBySchoolIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetPendingExamMarkInfoBySchoolIdSpRequestHandler(ISchoolManagementRepository<ClassRoutine> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetPendingExamMarkInfoBySchoolIdSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetPendingExamEvaluation] {0}", request.BaseSchoolNameId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
