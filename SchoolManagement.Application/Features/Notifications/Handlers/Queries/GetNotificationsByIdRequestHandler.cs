using AutoMapper;
using SchoolManagement.Application.DTOs.Notification;
using SchoolManagement.Application.Features.Notifications.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Notifications.Handlers.Queries   
{
    public class GetNotificationsByIdRequestHandler : IRequestHandler<GetNotificationsByIdRequest, List<NotificationDto>>
    {

        private readonly ISchoolManagementRepository<Notification> _NotificationRepository;

        private readonly IMapper _mapper;

        public GetNotificationsByIdRequestHandler(ISchoolManagementRepository<Notification> NotificationRepository, IMapper mapper)
        {
            _NotificationRepository = NotificationRepository;
            _mapper = mapper;
        }

        public async Task<List<NotificationDto>> Handle(GetNotificationsByIdRequest request, CancellationToken cancellationToken)
        {
            //if(request.UserRole == "Super Admin")
            //{
            //    IQueryable<Notification> Notifications = _NotificationRepository.FilterWithInclude(x => x.SendBaseSchoolNameId == request.TargetId || x.ReceivedBaseSchoolNameId == request.TargetId);
            //    var NotificationDtos = _mapper.Map<List<NotificationDto>>(Notifications);
            //    return NotificationDtos;
            //}
            //else 
            //if(request.UserRole == "Master Admin" || request.UserRole == "DDNT")
            //{
            //    IQueryable<Notification> Notifications = _NotificationRepository.FilterWithInclude(x => (x.SenderRole == request.UserRole && x.ReceivedBaseSchoolNameId == request.TargetId) || ((x.SenderRole == "Super Admin" || x.SenderRole == "School OIC") && x.SendBaseSchoolNameId == request.TargetId && x.ReceivedBaseSchoolNameId == null));
            //    var NotificationDtos = _mapper.Map<List<NotificationDto>>(Notifications);
            //    return NotificationDtos;
            //}
            //else
            //{
                IQueryable<Notification> Notifications = _NotificationRepository.FilterWithInclude(x => (x.SenderRole == request.UserRole && x.SendBaseSchoolNameId == request.SenderId && x.ReceivedBaseSchoolNameId == request.ReciverId) || ((x.SenderRole == "Super Admin" || x.SenderRole == "School OIC") && x.ReceiverRole==request.UserRole && x.SendBaseSchoolNameId == request.SenderId && x.ReceivedBaseSchoolNameId == request.ReciverId) || (x.SenderRole==request.UserRole && x.ReceivedBaseSchoolNameId == request.SenderId) || (x.ReceiverRole == request.UserRole && x.ReceivedBaseSchoolNameId == request.SenderId));
                var NotificationDtos = _mapper.Map<List<NotificationDto>>(Notifications);
                return NotificationDtos;
            //}
            //return null;
        }
    }
}
