using AutoMapper;
using SchoolManagement.Application.DTOs.UtofficerCategory.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.UtofficerCategorys.Requests.Commands;
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

namespace SchoolManagement.Application.Features.UtofficerCategorys.Handlers.Commands
{
    public class CreateUtofficerCategoryCommandHandler : IRequestHandler<CreateUtofficerCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUtofficerCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateUtofficerCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateUtofficerCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UtofficerCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var UtofficerCategory = _mapper.Map<UtofficerCategory>(request.UtofficerCategoryDto);

                UtofficerCategory = await _unitOfWork.Repository<UtofficerCategory>().Add(UtofficerCategory);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = UtofficerCategory.UtofficerCategoryId;
            }

            return response;
        }
    }
}
