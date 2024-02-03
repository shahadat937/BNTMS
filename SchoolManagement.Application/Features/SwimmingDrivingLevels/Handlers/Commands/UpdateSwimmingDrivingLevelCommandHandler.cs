using AutoMapper;
using SchoolManagement.Application.DTOs.SwimmingDrivingLevel.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SwimmingDrivingLevels.Handlers.Commands
{
    public class UpdateSwimmingDrivingLevelCommandHandler : IRequestHandler<UpdateSwimmingDrivingLevelCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSwimmingDrivingLevelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSwimmingDrivingLevelCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSwimmingDrivingLevelDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SwimmingDrivingLevelDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SwimmingDrivingLevels = await _unitOfWork.Repository<SwimmingDrivingLevel>().Get(request.SwimmingDrivingLevelDto.SwimmingDrivingLevelId);

            if (SwimmingDrivingLevels is null)
                throw new NotFoundException(nameof(SwimmingDrivingLevel), request.SwimmingDrivingLevelDto.SwimmingDrivingLevelId);

            _mapper.Map(request.SwimmingDrivingLevelDto, SwimmingDrivingLevels);

            await _unitOfWork.Repository<SwimmingDrivingLevel>().Update(SwimmingDrivingLevels);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
