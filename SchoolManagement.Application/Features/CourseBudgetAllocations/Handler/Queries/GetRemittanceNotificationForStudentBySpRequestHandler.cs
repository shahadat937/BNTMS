using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Handlers.Queries
{
    public class GetRemittanceNotificationForStudentBySpRequestHandler : IRequestHandler<GetRemittanceNotificationForStudentBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetRemittanceNotificationForStudentBySpRequestHandler(ISchoolManagementRepository<ClassRoutine> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetRemittanceNotificationForStudentBySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetTraineeRemittanceNotification] {0},{1}", request.TraineeId, request.CourseDurationId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
