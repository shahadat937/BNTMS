using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Assessment.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Assessments.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Assessments.Handlers.Commands
{
    public class UpdateAssessmentCommandHandler : IRequestHandler<UpdateAssessmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAssessmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAssessmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAssessmentDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AssessmentDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Assessment = await _unitOfWork.Repository<Assessment>().Get(request.AssessmentDto.AssessmentId);

            if (Assessment is null)
                throw new NotFoundException(nameof(Assessment), request.AssessmentDto.AssessmentId);

            _mapper.Map(request.AssessmentDto, Assessment);

            await _unitOfWork.Repository<Assessment>().Update(Assessment);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
