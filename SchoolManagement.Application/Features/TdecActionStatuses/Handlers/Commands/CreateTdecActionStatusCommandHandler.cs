using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TdecActionStatus.Validators;
using SchoolManagement.Application.Features.TdecActionStatuses.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecActionStatuses.Handlers.Commands
{
    public class CreateTdecActionStatusCommandHandler : IRequestHandler<CreateTdecActionStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTdecActionStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTdecActionStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTdecActionStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TdecActionStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TdecActionStatus = _mapper.Map<TdecActionStatus>(request.TdecActionStatusDto);

                TdecActionStatus = await _unitOfWork.Repository<TdecActionStatus>().Add(TdecActionStatus);
               
                    await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TdecActionStatus.TdecActionStatusId;
            }

            return response;
        }
    }
}
