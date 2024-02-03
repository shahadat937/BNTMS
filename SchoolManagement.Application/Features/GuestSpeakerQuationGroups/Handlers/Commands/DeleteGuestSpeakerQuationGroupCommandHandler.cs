using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Handlers.Commands
{
    public class DeleteGuestSpeakerQuationGroupCommandHandler : IRequestHandler<DeleteGuestSpeakerQuationGroupCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGuestSpeakerQuationGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGuestSpeakerQuationGroupCommand request, CancellationToken cancellationToken)
        {
            var GuestSpeakerQuationGroup = await _unitOfWork.Repository<GuestSpeakerQuationGroup>().Get(request.GuestSpeakerQuationGroupId);

            if (GuestSpeakerQuationGroup == null)
                throw new NotFoundException(nameof(GuestSpeakerQuationGroup), request.GuestSpeakerQuationGroupId);

            await _unitOfWork.Repository<GuestSpeakerQuationGroup>().Delete(GuestSpeakerQuationGroup);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
