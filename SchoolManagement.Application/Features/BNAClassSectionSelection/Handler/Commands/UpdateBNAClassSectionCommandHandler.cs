using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassSectionSelection.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaClassSections.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassSections.Handler.Commands
{
    public class UpdateBnaClassSectionCommandHandler : IRequestHandler<UpdateBnaClassSectionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaClassSectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaClassSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaClassSectionSelectionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaClassSectionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaClassSection = await _unitOfWork.Repository<BnaClassSectionSelection>().Get(request.BnaClassSectionDto.BnaClassSectionSelectionId);

            if (BnaClassSection is null)
                throw new NotFoundException(nameof(BnaClassSection), request.BnaClassSectionDto.BnaClassSectionSelectionId);

            _mapper.Map(request.BnaClassSectionDto, BnaClassSection);

            await _unitOfWork.Repository<BnaClassSectionSelection>().Update(BnaClassSection);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}