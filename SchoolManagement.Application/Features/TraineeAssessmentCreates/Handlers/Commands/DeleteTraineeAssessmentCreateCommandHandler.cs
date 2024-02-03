using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Handlers.Commands
{
    public class DeleteTraineeAssessmentCreateCommandHandler : IRequestHandler<DeleteTraineeAssessmentCreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTraineeAssessmentCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTraineeAssessmentCreateCommand request, CancellationToken cancellationToken)
        {
            var TraineeAssessmentCreates = await _unitOfWork.Repository<TraineeAssessmentCreate>().Get(request.TraineeAssessmentCreateId);

            if (TraineeAssessmentCreates == null)
                throw new NotFoundException(nameof(TraineeAssessmentCreate), request.TraineeAssessmentCreateId);

            await _unitOfWork.Repository<TraineeAssessmentCreate>().Delete(TraineeAssessmentCreates);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
