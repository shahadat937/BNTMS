using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ResultStatus.Validators;
using SchoolManagement.Application.Features.ResultStatuses.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ResultStatuses.Handlers.Commands
{
    public class CreateResultStatusCommandHandler : IRequestHandler<CreateResultStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateResultStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateResultStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateResultStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ResultStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ResultStatus = _mapper.Map<ResultStatus>(request.ResultStatusDto);

                ResultStatus = await _unitOfWork.Repository<ResultStatus>().Add(ResultStatus);
                await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ResultStatus.ResultStatusId;
            }

            return response;
        }
    }
}
