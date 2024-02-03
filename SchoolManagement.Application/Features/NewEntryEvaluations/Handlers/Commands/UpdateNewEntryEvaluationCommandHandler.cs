using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.NewEntryEvaluation.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NewEntryEvaluations.Handlers.Commands
{
    public class UpdateNewEntryEvaluationCommandHandler : IRequestHandler<UpdateNewEntryEvaluationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNewEntryEvaluationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNewEntryEvaluationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNewEntryEvaluationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.NewEntryEvaluationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var NewEntryEvaluation = await _unitOfWork.Repository<NewEntryEvaluation>().Get(request.NewEntryEvaluationDto.NewEntryEvaluationId);

            if (NewEntryEvaluation is null)
                throw new NotFoundException(nameof(NewEntryEvaluation), request.NewEntryEvaluationDto.NewEntryEvaluationId);

            _mapper.Map(request.NewEntryEvaluationDto, NewEntryEvaluation);

            await _unitOfWork.Repository<NewEntryEvaluation>().Update(NewEntryEvaluation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
