using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Handlers.Commands
{
    public class DeleteGuestSpeakerActionStatusCommandHandler : IRequestHandler<DeleteGuestSpeakerActionStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGuestSpeakerActionStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGuestSpeakerActionStatusCommand request, CancellationToken cancellationToken)
        {
            var GuestSpeakerActionStatus = await _unitOfWork.Repository<GuestSpeakerActionStatus>().Get(request.GuestSpeakerActionStatusId);

            if (GuestSpeakerActionStatus == null)
                throw new NotFoundException(nameof(GuestSpeakerActionStatus), request.GuestSpeakerActionStatusId);

            await _unitOfWork.Repository<GuestSpeakerActionStatus>().Delete(GuestSpeakerActionStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
