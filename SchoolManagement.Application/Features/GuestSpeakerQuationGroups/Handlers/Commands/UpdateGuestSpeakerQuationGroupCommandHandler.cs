using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Handlers.Commands
{
    public class UpdateGuestSpeakerQuationGroupCommandHandler : IRequestHandler<UpdateGuestSpeakerQuationGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGuestSpeakerQuationGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGuestSpeakerQuationGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGuestSpeakerQuationGroupDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.GuestSpeakerQuationGroupDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var GuestSpeakerQuationGroup = await _unitOfWork.Repository<GuestSpeakerQuationGroup>().Get(request.GuestSpeakerQuationGroupDto.GuestSpeakerQuationGroupId);

            if (GuestSpeakerQuationGroup is null)
                throw new NotFoundException(nameof(GuestSpeakerQuationGroup), request.GuestSpeakerQuationGroupDto.GuestSpeakerQuationGroupId);

            _mapper.Map(request.GuestSpeakerQuationGroupDto, GuestSpeakerQuationGroup);

            await _unitOfWork.Repository<GuestSpeakerQuationGroup>().Update(GuestSpeakerQuationGroup);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
