using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.GuestSpeakerActionStatus.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Handlers.Commands
{
    public class UpdateGuestSpeakerActionStatusCommandHandler : IRequestHandler<UpdateGuestSpeakerActionStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGuestSpeakerActionStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGuestSpeakerActionStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGuestSpeakerActionStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.GuestSpeakerActionStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var GuestSpeakerActionStatus = await _unitOfWork.Repository<GuestSpeakerActionStatus>().Get(request.GuestSpeakerActionStatusDto.GuestSpeakerActionStatusId);

            if (GuestSpeakerActionStatus is null)
                throw new NotFoundException(nameof(GuestSpeakerActionStatus), request.GuestSpeakerActionStatusDto.GuestSpeakerActionStatusId);

            _mapper.Map(request.GuestSpeakerActionStatusDto, GuestSpeakerActionStatus);

            await _unitOfWork.Repository<GuestSpeakerActionStatus>().Update(GuestSpeakerActionStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
