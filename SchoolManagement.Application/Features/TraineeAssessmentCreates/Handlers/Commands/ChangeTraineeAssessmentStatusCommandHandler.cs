using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Bulletins.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Bulletins.Handlers.Commands
{
    public class ChangeTraineeAssessmentStatusCommandHandler : IRequestHandler<ChangeTraineeAssessmentStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;
         
        public ChangeTraineeAssessmentStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ChangeTraineeAssessmentStatusCommand request, CancellationToken cancellationToken)
        {
            var Bulletin = await _unitOfWork.Repository<TraineeAssessmentCreate>().Get(request.TraineeAssessmentCreateId);
            Bulletin.Status = request.Status;

            if (Bulletin == null)
                throw new NotFoundException(nameof(Bulletin), request.TraineeAssessmentCreateId);

            await _unitOfWork.Repository<TraineeAssessmentCreate>().Update(Bulletin);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
