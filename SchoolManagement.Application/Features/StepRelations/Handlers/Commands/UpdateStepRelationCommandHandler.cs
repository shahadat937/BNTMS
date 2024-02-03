using AutoMapper;
using SchoolManagement.Application.DTOs.StepRelation.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.StepRelations.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.StepRelations.Handlers.Commands
{
    public class UpdateStepRelationCommandHandler : IRequestHandler<UpdateStepRelationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStepRelationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStepRelationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStepRelationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.StepRelationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var StepRelation = await _unitOfWork.Repository<StepRelation>().Get(request.StepRelationDto.StepRelationId);

            if (StepRelation is null)
                throw new NotFoundException(nameof(StepRelation), request.StepRelationDto.StepRelationId);

            _mapper.Map(request.StepRelationDto, StepRelation);

            await _unitOfWork.Repository<StepRelation>().Update(StepRelation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
