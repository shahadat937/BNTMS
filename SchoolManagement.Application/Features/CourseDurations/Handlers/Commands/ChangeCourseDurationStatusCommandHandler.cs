using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseDurations.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Commands
{
    public class ChangeCourseDurationStatusCommandHandler : IRequestHandler<ChangeCourseDurationStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public ChangeCourseDurationStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ChangeCourseDurationStatusCommand request, CancellationToken cancellationToken)
        {
            var CourseDuration = await _unitOfWork.Repository<CourseDuration>().Get(request.CourseDurationId);
            CourseDuration.IsCompletedStatus = request.IsCompletedStatus;

            if (CourseDuration == null)
                throw new NotFoundException(nameof(CourseDuration), request.CourseDurationId);

            await _unitOfWork.Repository<CourseDuration>().Update(CourseDuration);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
