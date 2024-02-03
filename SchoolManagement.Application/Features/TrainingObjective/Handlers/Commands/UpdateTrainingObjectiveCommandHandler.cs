using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.TrainingObjective.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TrainingObjectives.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TrainingObjectives.Handlers.Commands
{
    public class UpdateTrainingObjectiveCommandHandler : IRequestHandler<UpdateTrainingObjectiveCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTrainingObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTrainingObjectiveCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTrainingObjectiveDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.TrainingObjectiveDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TrainingObjective = await _unitOfWork.Repository<TrainingObjective>().Get(request.TrainingObjectiveDto.TrainingObjectiveId);

            if (TrainingObjective is null)
                throw new NotFoundException(nameof(TrainingObjective), request.TrainingObjectiveDto.TrainingObjectiveId);

            _mapper.Map(request.TrainingObjectiveDto, TrainingObjective);

            await _unitOfWork.Repository<TrainingObjective>().Update(TrainingObjective);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
