using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseDurations.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Commands
{
    public class StopInterServiceCommandHandler : IRequestHandler<StopInterServiceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StopInterServiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(StopInterServiceCommand request, CancellationToken cancellationToken)
        {
            var CourseDuration = await _unitOfWork.Repository<CourseDuration>().Get(request.CourseDurationId);
            CourseDuration.IsCompletedStatus = 1;

            if (CourseDuration == null)
                throw new NotFoundException(nameof(CourseDuration), request.CourseDurationId);

            await _unitOfWork.Repository<CourseDuration>().Update(CourseDuration);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
