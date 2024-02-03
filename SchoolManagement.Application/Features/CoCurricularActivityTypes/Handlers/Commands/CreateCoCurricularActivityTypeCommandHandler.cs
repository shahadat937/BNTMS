using AutoMapper;
using SchoolManagement.Application.DTOs.CoCurricularActivityType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Commands;
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

namespace SchoolManagement.Application.Features.CoCurricularActivityTypes.Handlers.Commands
{
    public class CreateCoCurricularActivityTypeCommandHandler : IRequestHandler<CreateCoCurricularActivityTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCoCurricularActivityTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCoCurricularActivityTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCoCurricularActivityTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CoCurricularActivityTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CoCurricularActivityType = _mapper.Map<CoCurricularActivityType>(request.CoCurricularActivityTypeDto);

                CoCurricularActivityType = await _unitOfWork.Repository<CoCurricularActivityType>().Add(CoCurricularActivityType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CoCurricularActivityType.CoCurricularActivityTypeId;
            }

            return response;
        }
    }
}
