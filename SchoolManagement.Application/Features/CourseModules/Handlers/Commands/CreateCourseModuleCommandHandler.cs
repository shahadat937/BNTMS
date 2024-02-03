using AutoMapper;
using SchoolManagement.Application.DTOs.CourseModule.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseModules.Requests.Commands;
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

namespace SchoolManagement.Application.Features.CourseModules.Handlers.Commands
{
    public class CreateCourseModuleCommandHandler : IRequestHandler<CreateCourseModuleCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseModuleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseModuleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseModuleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseModuleDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CourseModules = _mapper.Map<CourseModule>(request.CourseModuleDto);

                CourseModules = await _unitOfWork.Repository<CourseModule>().Add(CourseModules);
                
                
                    await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CourseModules.CourseModuleId;
            }

            return response;
        }
    }
}
