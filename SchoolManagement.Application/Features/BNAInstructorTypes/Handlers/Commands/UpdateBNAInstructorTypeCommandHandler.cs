using AutoMapper;
using SchoolManagement.Application.DTOs.BnaInstructorType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaInstructorTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaInstructorTypes.Handlers.Commands
{
    public class UpdateBnaInstructorTypeCommandHandler : IRequestHandler<UpdateBnaInstructorTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaInstructorTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaInstructorTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaInstructorTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaInstructorTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaInstructorType = await _unitOfWork.Repository<BnaInstructorType>().Get(request.BnaInstructorTypeDto.BnaInstructorTypeId);

            if (BnaInstructorType is null)
                throw new NotFoundException(nameof(BnaInstructorType), request.BnaInstructorTypeDto.BnaInstructorTypeId);

            _mapper.Map(request.BnaInstructorTypeDto, BnaInstructorType);

            await _unitOfWork.Repository<BnaInstructorType>().Update(BnaInstructorType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
