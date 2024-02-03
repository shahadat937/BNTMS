using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.TdecActionStatus.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TdecActionStatuses.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecActionStatuses.Handlers.Commands
{
    public class UpdateTdecActionStatusCommandHandler : IRequestHandler<UpdateTdecActionStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTdecActionStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTdecActionStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTdecActionStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.TdecActionStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TdecActionStatus = await _unitOfWork.Repository<TdecActionStatus>().Get(request.TdecActionStatusDto.TdecActionStatusId);

            if (TdecActionStatus is null)
                throw new NotFoundException(nameof(TdecActionStatus), request.TdecActionStatusDto.TdecActionStatusId);

            _mapper.Map(request.TdecActionStatusDto, TdecActionStatus);

            await _unitOfWork.Repository<TdecActionStatus>().Update(TdecActionStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
