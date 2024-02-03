using AutoMapper;
using SchoolManagement.Application.DTOs.BnaInstructorType.Validators;
using SchoolManagement.Application.Exceptions;
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
using SchoolManagement.Application.Features.BnaInstructorTypes.Requests.Commands;

namespace SchoolManagement.Application.Features.BnaInstructorTypes.Handlers.Commands
{
    public class CreateBnaInstructorTypeCommandHandler : IRequestHandler<CreateBnaInstructorTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaInstructorTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaInstructorTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaInstructorTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaInstructorTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaInstructorType = _mapper.Map<BnaInstructorType>(request.BnaInstructorTypeDto);

                BnaInstructorType = await _unitOfWork.Repository<BnaInstructorType>().Add(BnaInstructorType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaInstructorType.BnaInstructorTypeId;
            }

            return response;
        }
    }
}
