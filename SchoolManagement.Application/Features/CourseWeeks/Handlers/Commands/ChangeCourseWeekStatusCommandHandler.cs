using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Commands
{
    public class ChangeCourseWeekStatusCommandHandler : IRequestHandler<ChangeCourseWeekStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public ChangeCourseWeekStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ChangeCourseWeekStatusCommand request, CancellationToken cancellationToken)
        {
            var CourseWeeks = await _unitOfWork.Repository<CourseWeek>().Get(request.CourseWeekId);
            CourseWeeks.Status = request.Status;

            if (CourseWeeks == null)
                throw new NotFoundException(nameof(CourseWeeks), request.CourseWeekId);

            await _unitOfWork.Repository<CourseWeek>().Update(CourseWeeks);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
