using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ExamCenter.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.ExamCenters.Requests.Commands;

namespace SchoolManagement.Application.Features.ExamCenters.Handlers.Commands
{
    public class UpdateExamCenterCommandHandler : IRequestHandler<UpdateExamCenterCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExamCenterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateExamCenterCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateExamCenterDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ExamCenterDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ExamCenter = await _unitOfWork.Repository<ExamCenter>().Get(request.ExamCenterDto.ExamCenterId);

            if (ExamCenter is null)
                throw new NotFoundException(nameof(ExamCenter), request.ExamCenterDto.ExamCenterId);

            _mapper.Map(request.ExamCenterDto, ExamCenter);

            await _unitOfWork.Repository<ExamCenter>().Update(ExamCenter);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
