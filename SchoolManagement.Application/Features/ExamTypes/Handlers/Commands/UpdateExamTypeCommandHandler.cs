using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ExamType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ExamTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamTypes.Handlers.Commands
{
    public class UpdateExamTypeCommandHandler : IRequestHandler<UpdateExamTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExamTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateExamTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateExamTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ExamTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ExamType = await _unitOfWork.Repository<ExamType>().Get(request.ExamTypeDto.ExamTypeId);

            if (ExamType is null)
                throw new NotFoundException(nameof(ExamType), request.ExamTypeDto.ExamTypeId);

            _mapper.Map(request.ExamTypeDto, ExamType);

            await _unitOfWork.Repository<ExamType>().Update(ExamType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
