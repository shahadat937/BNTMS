using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Commands
{
    public class RunningCourseInstructorCommandHandler : IRequestHandler<RunningCourseInstructorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RunningCourseInstructorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(RunningCourseInstructorCommand request, CancellationToken cancellationToken)
        {
            var CourseInstructor = await _unitOfWork.Repository<CourseInstructor>().Get(request.CourseInstructorId);
            CourseInstructor.Status = 0;

            if (CourseInstructor == null)
                throw new NotFoundException(nameof(CourseInstructor), request.CourseInstructorId);

            await _unitOfWork.Repository<CourseInstructor>().Update(CourseInstructor);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
