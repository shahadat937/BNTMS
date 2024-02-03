using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Notification.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Notifications.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Notifications.Handlers.Commands
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNotificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNotificationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.NotificationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Notification = await _unitOfWork.Repository<Notification>().Get(request.NotificationDto.NotificationId);

            if (Notification is null)
                throw new NotFoundException(nameof(Notification), request.NotificationDto.NotificationId);

            _mapper.Map(request.NotificationDto, Notification);

            await _unitOfWork.Repository<Notification>().Update(Notification);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
