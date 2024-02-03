using SchoolManagement.Application.Features.Notifications.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Notification;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;


namespace SchoolManagement.Application.Features.Notifications.Handlers.Queries
{
    public class GetNotificationListRequestHandler : IRequestHandler<GetNotificationListRequest, PagedResult<NotificationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Notification> _NotificationRepository;

        private readonly IMapper _mapper;

        public GetNotificationListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Notification> NotificationRepository, IMapper mapper)
        {
            _NotificationRepository = NotificationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<NotificationDto>> Handle(GetNotificationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.Notification> Notifications = _NotificationRepository.FilterWithInclude(x => (x.Notes.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Notifications.Count();
            Notifications = Notifications.OrderByDescending(x => x.NotificationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var NotificationDtos = _mapper.Map<List<NotificationDto>>(Notifications);
            var result = new PagedResult<NotificationDto>(NotificationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
