using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeAssessmentMark.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Handlers.Commands
{
    public class UpdateTraineeAssessmentMarkCommandHandler : IRequestHandler<UpdateTraineeAssessmentMarkCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTraineeAssessmentMarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTraineeAssessmentMarkCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTraineeAssessmentMarkDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeAssessmentMarkDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TraineeAssessmentMarks = await _unitOfWork.Repository<TraineeAssessmentMark>().Get(request.TraineeAssessmentMarkDto.TraineeAssessmentMarkId);

            if (TraineeAssessmentMarks is null)
                throw new NotFoundException(nameof(TraineeAssessmentMark), request.TraineeAssessmentMarkDto.TraineeAssessmentMarkId);

            _mapper.Map(request.TraineeAssessmentMarkDto, TraineeAssessmentMarks);

            await _unitOfWork.Repository<TraineeAssessmentMark>().Update(TraineeAssessmentMarks);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
