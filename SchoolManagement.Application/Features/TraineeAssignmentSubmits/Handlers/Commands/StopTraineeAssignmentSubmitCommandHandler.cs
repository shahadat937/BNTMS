using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Handlers.Commands
{
    public class StopTraineeAssignmentSubmitCommandHandler : IRequestHandler<StopTraineeAssignmentSubmitCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StopTraineeAssignmentSubmitCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(StopTraineeAssignmentSubmitCommand request, CancellationToken cancellationToken)
        {
            var TraineeAssignmentSubmit = await _unitOfWork.Repository<TraineeAssignmentSubmit>().Get(request.TraineeAssignmentSubmitId);
            TraineeAssignmentSubmit.Status = 1;

            if (TraineeAssignmentSubmit == null)
                throw new NotFoundException(nameof(TraineeAssignmentSubmit), request.TraineeAssignmentSubmitId);

            await _unitOfWork.Repository<TraineeAssignmentSubmit>().Update(TraineeAssignmentSubmit);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
