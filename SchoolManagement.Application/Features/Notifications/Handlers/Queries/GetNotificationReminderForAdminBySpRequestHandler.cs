using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Notifications.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Notifications.Handlers.Queries
{
    public class GetNotificationReminderForAdminBySpRequestHandler : IRequestHandler<GetNotificationReminderForAdminBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<Notification> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetNotificationReminderForAdminBySpRequestHandler(ISchoolManagementRepository<Notification> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetNotificationReminderForAdminBySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetNotificationReminderForAdmin] {0},'{1}'", request.BaseSchoolNameId, request.UserRole);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
