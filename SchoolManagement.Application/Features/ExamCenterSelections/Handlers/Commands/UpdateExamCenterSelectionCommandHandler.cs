using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ExamCenterSelection.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.ExamCenterSelections.Requests.Commands;

namespace SchoolManagement.Application.Features.ExamCenterSelections.Handlers.Commands
{
    public class UpdateExamCenterSelectionCommandHandler : IRequestHandler<UpdateExamCenterSelectionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExamCenterSelectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateExamCenterSelectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateExamCenterSelectionDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ExamCenterSelectionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ExamCenterSelection = await _unitOfWork.Repository<ExamCenterSelection>().Get(request.ExamCenterSelectionDto.ExamCenterSelectionId);

            if (ExamCenterSelection is null)
                throw new NotFoundException(nameof(ExamCenterSelection), request.ExamCenterSelectionDto.ExamCenterSelectionId);

            _mapper.Map(request.ExamCenterSelectionDto, ExamCenterSelection);

            await _unitOfWork.Repository<ExamCenterSelection>().Update(ExamCenterSelection);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
