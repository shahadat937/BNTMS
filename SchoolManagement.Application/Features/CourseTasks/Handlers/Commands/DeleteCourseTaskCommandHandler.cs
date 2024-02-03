using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseTasks.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseTasks.Handlers.Commands
{
    public class DeleteCourseTaskCommandHandler : IRequestHandler<DeleteCourseTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseTaskCommand request, CancellationToken cancellationToken)
        {
            var CourseTask = await _unitOfWork.Repository<CourseTask>().Get(request.CourseTaskId);

            if (CourseTask == null)
                throw new NotFoundException(nameof(CourseTask), request.CourseTaskId);

            await _unitOfWork.Repository<CourseTask>().Delete(CourseTask);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
