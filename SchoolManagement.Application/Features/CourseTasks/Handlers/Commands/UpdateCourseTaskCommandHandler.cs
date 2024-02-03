using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.CourseTask.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseTasks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseTasks.Handlers.Commands
{
    public class UpdateCourseTaskCommandHandler : IRequestHandler<UpdateCourseTaskCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCourseTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCourseTaskCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCourseTaskDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CourseTaskDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CourseTask = await _unitOfWork.Repository<CourseTask>().Get(request.CourseTaskDto.CourseTaskId);

            if (CourseTask is null)
                throw new NotFoundException(nameof(CourseTask), request.CourseTaskDto.CourseTaskId);

            _mapper.Map(request.CourseTaskDto, CourseTask);

            await _unitOfWork.Repository<CourseTask>().Update(CourseTask);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
