using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CurrencyName.Validators;
using SchoolManagement.Application.Features.CurrencyNames.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CurrencyNames.Handlers.Commands
{
    public class CreateCurrencyNameCommandHandler : IRequestHandler<CreateCurrencyNameCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCurrencyNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCurrencyNameCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCurrencyNameDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CurrencyNameDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CurrencyName = _mapper.Map<CurrencyName>(request.CurrencyNameDto);

                CurrencyName = await _unitOfWork.Repository<CurrencyName>().Add(CurrencyName);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CurrencyName.CurrencyNameId;
            }

            return response;
        }
    }
}
