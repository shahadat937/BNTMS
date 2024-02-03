using AutoMapper;
using SchoolManagement.Application.DTOs.UtofficerCategory.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.UtofficerCategorys.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.UtofficerCategorys.Handlers.Commands
{
    public class UpdateUtofficerCategoryCommandHandler : IRequestHandler<UpdateUtofficerCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUtofficerCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUtofficerCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUtofficerCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UtofficerCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var UtofficerCategory = await _unitOfWork.Repository<UtofficerCategory>().Get(request.UtofficerCategoryDto.UtofficerCategoryId);

            if (UtofficerCategory is null)
                throw new NotFoundException(nameof(UtofficerCategory), request.UtofficerCategoryDto.UtofficerCategoryId);

            _mapper.Map(request.UtofficerCategoryDto, UtofficerCategory);

            await _unitOfWork.Repository<UtofficerCategory>().Update(UtofficerCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
