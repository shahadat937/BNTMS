using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ExamAttemptType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Commands;

namespace SchoolManagement.Application.Features.ExamAttemptTypes.Handlers.Commands
{
    public class UpdateExamAttemptTypeCommandHandler : IRequestHandler<UpdateExamAttemptTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExamAttemptTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateExamAttemptTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateExamAttemptTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ExamAttemptTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ExamAttemptType = await _unitOfWork.Repository<ExamAttemptType>().Get(request.ExamAttemptTypeDto.ExamAttemptTypeId);

            if (ExamAttemptType is null)
                throw new NotFoundException(nameof(ExamAttemptType), request.ExamAttemptTypeDto.ExamAttemptTypeId);

            _mapper.Map(request.ExamAttemptTypeDto, ExamAttemptType);

            await _unitOfWork.Repository<ExamAttemptType>().Update(ExamAttemptType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
