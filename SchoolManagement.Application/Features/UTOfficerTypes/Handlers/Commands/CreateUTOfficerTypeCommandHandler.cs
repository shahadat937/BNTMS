using AutoMapper;
using SchoolManagement.Application.DTOs.UtofficerType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.UtofficerTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.UtofficerTypes.Handlers.Commands
{
    public class CreateUtofficerTypeCommandHandler : IRequestHandler<CreateUtofficerTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUtofficerTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateUtofficerTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateUtofficerTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UtofficerTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var UtofficerType = _mapper.Map<UtofficerType>(request.UtofficerTypeDto);

                UtofficerType = await _unitOfWork.Repository<UtofficerType>().Add(UtofficerType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = UtofficerType.UtofficerTypeId;
            }

            return response;
        }
    }
}
