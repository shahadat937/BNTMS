using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Handlers.Commands
{
    public class DeleteGuestSpeakerQuestionNameCommandHandler : IRequestHandler<DeleteGuestSpeakerQuestionNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGuestSpeakerQuestionNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGuestSpeakerQuestionNameCommand request, CancellationToken cancellationToken)
        {
            var GuestSpeakerQuestionName = await _unitOfWork.Repository<GuestSpeakerQuestionName>().Get(request.GuestSpeakerQuestionNameId);

            if (GuestSpeakerQuestionName == null)
                throw new NotFoundException(nameof(GuestSpeakerQuestionName), request.GuestSpeakerQuestionNameId);

            await _unitOfWork.Repository<GuestSpeakerQuestionName>().Delete(GuestSpeakerQuestionName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
