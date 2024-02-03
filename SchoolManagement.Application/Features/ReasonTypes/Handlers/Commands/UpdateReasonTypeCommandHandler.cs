using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ReasonType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ReasonTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReasonTypes.Handlers.Commands
{
    public class UpdateReasonTypeCommandHandler : IRequestHandler<UpdateReasonTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateReasonTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateReasonTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateReasonTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ReasonTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ReasonType = await _unitOfWork.Repository<ReasonType>().Get(request.ReasonTypeDto.ReasonTypeId);

            if (ReasonType is null)
                throw new NotFoundException(nameof(ReasonType), request.ReasonTypeDto.ReasonTypeId);

            _mapper.Map(request.ReasonTypeDto, ReasonType);

            await _unitOfWork.Repository<ReasonType>().Update(ReasonType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
