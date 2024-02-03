using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InterServiceCourseDocType.Validators;
using SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceCourseDocTypes.Handlers.Commands
{
    public class CreateInterServiceCourseDocTypeCommandHandler : IRequestHandler<CreateInterServiceCourseDocTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateInterServiceCourseDocTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateInterServiceCourseDocTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateInterServiceCourseDocTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.InterServiceCourseDocTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var InterServiceCourseDocType = _mapper.Map<InterServiceCourseDocType>(request.InterServiceCourseDocTypeDto);

                InterServiceCourseDocType = await _unitOfWork.Repository<InterServiceCourseDocType>().Add(InterServiceCourseDocType);
                await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = InterServiceCourseDocType.InterServiceCourseDocTypeId;
            }

            return response;
        }
    }
}
