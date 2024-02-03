using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Commands
{
    public class DeleteCourseInstructorCommandHandler : IRequestHandler<DeleteCourseInstructorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseInstructorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseInstructorCommand request, CancellationToken cancellationToken)
        {
            var CourseInstructor = await _unitOfWork.Repository<CourseInstructor>().Get(request.CourseInstructorId);

            if (CourseInstructor == null)
                throw new NotFoundException(nameof(CourseInstructor), request.CourseInstructorId);

            await _unitOfWork.Repository<CourseInstructor>().Delete(CourseInstructor);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
