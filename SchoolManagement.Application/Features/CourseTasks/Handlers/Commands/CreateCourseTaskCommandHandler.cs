using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseTask.Validators;
using SchoolManagement.Application.Features.CourseTasks.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseTasks.Handlers.Commands
{
    public class CreateCourseTaskCommandHandler : IRequestHandler<CreateCourseTaskCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseTaskCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCourseTaskDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CourseTaskDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var courseTasks = _mapper.Map<CourseTask>(request.CourseTaskDto);
                courseTasks.Status = 0;
                courseTasks = await _unitOfWork.Repository<CourseTask>().Add(courseTasks);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = courseTasks.CourseTaskId;
            }

            return response;
        }
    }
}
