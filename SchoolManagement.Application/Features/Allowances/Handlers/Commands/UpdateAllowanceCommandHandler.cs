using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Allowance.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.Allowances.Requests.Commands;

namespace SchoolManagement.Application.Features.Allowances.Handlers.Commands
{
    public class UpdateAllowanceCommandHandler : IRequestHandler<UpdateAllowanceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAllowanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAllowanceCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAllowanceDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.AllowanceDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Allowance = await _unitOfWork.Repository<Allowance>().Get(request.AllowanceDto.AllowanceId);

            if (Allowance is null)
                throw new NotFoundException(nameof(Allowance), request.AllowanceDto.AllowanceId);

            _mapper.Map(request.AllowanceDto, Allowance);

            await _unitOfWork.Repository<Allowance>().Update(Allowance);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
