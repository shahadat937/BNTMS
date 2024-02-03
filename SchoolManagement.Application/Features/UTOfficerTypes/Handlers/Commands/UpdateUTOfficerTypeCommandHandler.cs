using AutoMapper;
using SchoolManagement.Application.DTOs.UtofficerType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.UtofficerTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.UtofficerTypes.Handlers.Commands
{
    public class UpdateUtofficerTypeCommandHandler : IRequestHandler<UpdateUtofficerTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUtofficerTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUtofficerTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUtofficerTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UtofficerTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var UtofficerType = await _unitOfWork.Repository<UtofficerType>().Get(request.UtofficerTypeDto.UtofficerTypeId);

            if (UtofficerType is null)
                throw new NotFoundException(nameof(UtofficerType), request.UtofficerTypeDto.UtofficerTypeId);

            _mapper.Map(request.UtofficerTypeDto, UtofficerType);

            await _unitOfWork.Repository<UtofficerType>().Update(UtofficerType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
