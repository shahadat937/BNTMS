using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Allowance.Validators;
using SchoolManagement.Application.Features.Allowances.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Allowances.Handlers.Commands
{
    public class CreateAllowanceCommandHandler : IRequestHandler<CreateAllowanceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAllowanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAllowanceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateAllowanceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AllowanceDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Allowance = _mapper.Map<Allowance>(request.AllowanceDto);
                Allowance.DurationFrom = Allowance.DurationFrom.Value.AddDays(1.0);
                Allowance.DurationTo = Allowance.DurationTo.Value.AddDays(1.0);
                Allowance = await _unitOfWork.Repository<Allowance>().Add(Allowance);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Allowance.AllowanceId;
            }

            return response;
        }
    }
}
