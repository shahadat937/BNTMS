using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ResultStatus.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ResultStatuses.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ResultStatuses.Handlers.Commands
{
    public class UpdateResultStatusCommandHandler : IRequestHandler<UpdateResultStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateResultStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateResultStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateResultStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ResultStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ResultStatus = await _unitOfWork.Repository<ResultStatus>().Get(request.ResultStatusDto.ResultStatusId);

            if (ResultStatus is null)
                throw new NotFoundException(nameof(ResultStatus), request.ResultStatusDto.ResultStatusId);

            _mapper.Map(request.ResultStatusDto, ResultStatus);

            await _unitOfWork.Repository<ResultStatus>().Update(ResultStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
