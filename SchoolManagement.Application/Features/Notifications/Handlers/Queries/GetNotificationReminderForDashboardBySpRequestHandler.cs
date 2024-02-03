using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Notifications.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Notifications.Handlers.Queries
{
    public class GetNotificationReminderForDashboardBySpRequestHandler : IRequestHandler<GetNotificationReminderForDashboardBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<Notification> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetNotificationReminderForDashboardBySpRequestHandler(ISchoolManagementRepository<Notification> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetNotificationReminderForDashboardBySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetNotificationReminderForDashboard] '{0}',{1}", request.UserRole,request.ReceiverId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
