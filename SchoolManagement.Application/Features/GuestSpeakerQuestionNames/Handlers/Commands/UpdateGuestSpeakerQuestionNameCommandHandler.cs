using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Handlers.Commands
{
    public class UpdateGuestSpeakerQuestionNameCommandHandler : IRequestHandler<UpdateGuestSpeakerQuestionNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGuestSpeakerQuestionNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGuestSpeakerQuestionNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGuestSpeakerQuestionNameDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.GuestSpeakerQuestionNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var GuestSpeakerQuestionName = await _unitOfWork.Repository<GuestSpeakerQuestionName>().Get(request.GuestSpeakerQuestionNameDto.GuestSpeakerQuestionNameId);

            if (GuestSpeakerQuestionName is null)
                throw new NotFoundException(nameof(GuestSpeakerQuestionName), request.GuestSpeakerQuestionNameDto.GuestSpeakerQuestionNameId);

            _mapper.Map(request.GuestSpeakerQuestionNameDto, GuestSpeakerQuestionName);

            await _unitOfWork.Repository<GuestSpeakerQuestionName>().Update(GuestSpeakerQuestionName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
