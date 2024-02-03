using AutoMapper;
using SchoolManagement.Application.DTOs.BnaServiceType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaServiceTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaServiceTypes.Handlers.Commands
{
    public class UpdateBnaServiceTypeCommandHandler : IRequestHandler<UpdateBnaServiceTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaServiceTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaServiceTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaServiceTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaServiceTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaServiceType = await _unitOfWork.Repository<BnaServiceType>().Get(request.BnaServiceTypeDto.BnaServiceTypeId);

            if (BnaServiceType is null)
                throw new NotFoundException(nameof(BnaServiceType), request.BnaServiceTypeDto.BnaServiceTypeId);

            _mapper.Map(request.BnaServiceTypeDto, BnaServiceType);

            await _unitOfWork.Repository<BnaServiceType>().Update(BnaServiceType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
