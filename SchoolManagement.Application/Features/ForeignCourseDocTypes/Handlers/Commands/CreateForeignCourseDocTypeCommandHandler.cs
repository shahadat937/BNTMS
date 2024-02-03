using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignCourseDocType.Validators;
using SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignCourseDocTypes.Handlers.Commands
{
    public class CreateForeignCourseDocTypeCommandHandler : IRequestHandler<CreateForeignCourseDocTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateForeignCourseDocTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateForeignCourseDocTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateForeignCourseDocTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ForeignCourseDocTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ForeignCourseDocType = _mapper.Map<ForeignCourseDocType>(request.ForeignCourseDocTypeDto);

                ForeignCourseDocType = await _unitOfWork.Repository<ForeignCourseDocType>().Add(ForeignCourseDocType);
                await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ForeignCourseDocType.ForeignCourseDocTypeId;
            }

            return response;
        }
    }
}
