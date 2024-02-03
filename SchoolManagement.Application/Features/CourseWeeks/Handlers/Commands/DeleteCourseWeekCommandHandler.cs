using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Commands
{
    public class DeleteCourseWeekCommandHandler : IRequestHandler<DeleteCourseWeekCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCourseWeekCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCourseWeekCommand request, CancellationToken cancellationToken)
        {
            var CourseWeek = await _unitOfWork.Repository<CourseWeek>().Get(request.CourseWeekId);

            if (CourseWeek == null)
                throw new NotFoundException(nameof(CourseWeek), request.CourseWeekId);

            await _unitOfWork.Repository<CourseWeek>().Delete(CourseWeek);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
