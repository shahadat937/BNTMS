using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Notifications.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Notifications.Handlers.Queries
{
    public class GetSelectedNotificationRequestHandler : IRequestHandler<GetSelectedNotificationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Notification> _NotificationRepository;


        public GetSelectedNotificationRequestHandler(ISchoolManagementRepository<Notification> NotificationRepository)
        {
            _NotificationRepository = NotificationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedNotificationRequest request, CancellationToken cancellationToken)
        {
            ICollection<Notification> codeValues = await _NotificationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Notes,
                Value = x.NotificationId
            }).ToList();
            return selectModels;
        }
    }
}
