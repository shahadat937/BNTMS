using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.WithdrawnType.Validators;
using SchoolManagement.Application.Features.WithdrawnTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WithdrawnTypes.Handlers.Commands
{
    public class CreateWithdrawnTypeCommandHandler : IRequestHandler<CreateWithdrawnTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateWithdrawnTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateWithdrawnTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateWithdrawnTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.WithdrawnTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var WithdrawnType = _mapper.Map<WithdrawnType>(request.WithdrawnTypeDto);

                WithdrawnType = await _unitOfWork.Repository<WithdrawnType>().Add(WithdrawnType);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = WithdrawnType.WithdrawnTypeId;
            }

            return response;
        }
    }
}
