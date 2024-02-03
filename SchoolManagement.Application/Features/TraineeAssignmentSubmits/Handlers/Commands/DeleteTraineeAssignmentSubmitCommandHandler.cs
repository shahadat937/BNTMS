using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Handlers.Commands
{
    public class DeleteTraineeAssignmentSubmitCommandHandler : IRequestHandler<DeleteTraineeAssignmentSubmitCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTraineeAssignmentSubmitCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTraineeAssignmentSubmitCommand request, CancellationToken cancellationToken)
        {
            var TraineeAssignmentSubmit = await _unitOfWork.Repository<TraineeAssignmentSubmit>().Get(request.TraineeAssignmentSubmitId);

            if (TraineeAssignmentSubmit == null)
                throw new NotFoundException(nameof(TraineeAssignmentSubmit), request.TraineeAssignmentSubmitId);

            await _unitOfWork.Repository<TraineeAssignmentSubmit>().Delete(TraineeAssignmentSubmit);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
