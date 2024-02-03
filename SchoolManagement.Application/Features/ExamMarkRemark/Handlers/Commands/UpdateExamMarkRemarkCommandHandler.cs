using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ExamMarkRemarks.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ExamMarkRemark.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamMarkRemark.Handlers.Commands
{
    public class UpdateExamMarkRemarkCommandHandler : IRequestHandler<UpdateExamMarkRemarkCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExamMarkRemarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateExamMarkRemarkCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateExamMarkRemarkDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ExamMarkRemarkDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ExamMarkRemark = await _unitOfWork.Repository<ExamMarkRemarks>().Get(request.ExamMarkRemarkDto.ExamMarkRemarksId);

            if (ExamMarkRemark is null)
                throw new NotFoundException(nameof(ExamMarkRemark), request.ExamMarkRemarkDto.ExamMarkRemarksId);

            _mapper.Map(request.ExamMarkRemarkDto, ExamMarkRemark);

            await _unitOfWork.Repository<ExamMarkRemarks>().Update(ExamMarkRemark);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
