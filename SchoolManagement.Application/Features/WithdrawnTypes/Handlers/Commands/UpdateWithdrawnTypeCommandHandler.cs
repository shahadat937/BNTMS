using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.WithdrawnType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.WithdrawnTypes.Requests.Commands;

namespace SchoolManagement.Application.Features.WithdrawnTypes.Handlers.Commands
{
    public class UpdateWithdrawnTypeCommandHandler : IRequestHandler<UpdateWithdrawnTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateWithdrawnTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWithdrawnTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateWithdrawnTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.WithdrawnTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var WithdrawnType = await _unitOfWork.Repository<WithdrawnType>().Get(request.WithdrawnTypeDto.WithdrawnTypeId);

            if (WithdrawnType is null)
                throw new NotFoundException(nameof(WithdrawnType), request.WithdrawnTypeDto.WithdrawnTypeId);

            _mapper.Map(request.WithdrawnTypeDto, WithdrawnType);

            await _unitOfWork.Repository<WithdrawnType>().Update(WithdrawnType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
