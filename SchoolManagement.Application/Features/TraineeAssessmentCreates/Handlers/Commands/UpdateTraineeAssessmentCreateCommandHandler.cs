using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeAssessmentCreate.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Handlers.Commands
{
    public class UpdateTraineeAssessmentCreateCommandHandler : IRequestHandler<UpdateTraineeAssessmentCreateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTraineeAssessmentCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTraineeAssessmentCreateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTraineeAssessmentCreateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeAssessmentCreateDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TraineeAssessmentCreates = await _unitOfWork.Repository<TraineeAssessmentCreate>().Get(request.TraineeAssessmentCreateDto.TraineeAssessmentCreateId);

            if (TraineeAssessmentCreates is null)
                throw new NotFoundException(nameof(TraineeAssessmentCreate), request.TraineeAssessmentCreateDto.TraineeAssessmentCreateId);

            _mapper.Map(request.TraineeAssessmentCreateDto, TraineeAssessmentCreates);

            await _unitOfWork.Repository<TraineeAssessmentCreate>().Update(TraineeAssessmentCreates);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
