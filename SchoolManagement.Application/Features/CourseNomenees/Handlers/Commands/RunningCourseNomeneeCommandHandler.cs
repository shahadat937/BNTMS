using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseNomenees.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseNomenees.Handlers.Commands
{
    public class RunningCourseNomeneeCommandHandler : IRequestHandler<RunningCourseNomeneeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RunningCourseNomeneeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(RunningCourseNomeneeCommand request, CancellationToken cancellationToken)
        {
            var CourseNomenee = await _unitOfWork.Repository<CourseNomenee>().Get(request.CourseNomeneeId);
            CourseNomenee.Status = 0;

            if (CourseNomenee == null)
                throw new NotFoundException(nameof(CourseNomenee), request.CourseNomeneeId);

            await _unitOfWork.Repository<CourseNomenee>().Update(CourseNomenee);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
