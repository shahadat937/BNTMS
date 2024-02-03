using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.CurrencyName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.CurrencyNames.Requests.Commands;

namespace SchoolManagement.Application.Features.CurrencyNames.Handlers.Commands
{
    public class UpdateCurrencyNameCommandHandler : IRequestHandler<UpdateCurrencyNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCurrencyNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCurrencyNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCurrencyNameDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CurrencyNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CurrencyName = await _unitOfWork.Repository<CurrencyName>().Get(request.CurrencyNameDto.CurrencyNameId);

            if (CurrencyName is null)
                throw new NotFoundException(nameof(CurrencyName), request.CurrencyNameDto.CurrencyNameId);

            _mapper.Map(request.CurrencyNameDto, CurrencyName);

            await _unitOfWork.Repository<CurrencyName>().Update(CurrencyName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
