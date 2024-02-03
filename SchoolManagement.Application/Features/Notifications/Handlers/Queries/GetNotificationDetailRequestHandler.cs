using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Notification;
using SchoolManagement.Application.Features.Notifications.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Notifications.Handlers.Queries
{
    public class GetNotificationDetailRequestHandler : IRequestHandler<GetNotificationDetailRequest, NotificationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Notification> _NotificationRepository;
        public GetNotificationDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Notification> NotificationRepository, IMapper mapper)
        {
            _NotificationRepository = NotificationRepository;
            _mapper = mapper;
        }
        public async Task<NotificationDto> Handle(GetNotificationDetailRequest request, CancellationToken cancellationToken)
        {
            var Notification = await _NotificationRepository.Get(request.NotificationId);
            return _mapper.Map<NotificationDto>(Notification);
        }
    }
}
