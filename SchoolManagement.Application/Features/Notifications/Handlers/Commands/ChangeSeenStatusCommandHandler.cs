using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Notifications.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Notifications.Handlers.Commands
{
    public class ChangeSeenStatusCommandHandler : IRequestHandler<ChangeSeenStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public ChangeSeenStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ChangeSeenStatusCommand request, CancellationToken cancellationToken)
        {
            var Notifications = await _unitOfWork.Repository<Notification>().Get(request.NotificationId);
            Notifications.ReciverSeenStatus = request.Status;

            if (Notifications == null)
                throw new NotFoundException(nameof(Notifications), request.NotificationId);

            await _unitOfWork.Repository<Notification>().Update(Notifications);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
