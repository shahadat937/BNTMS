using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Handlers.Commands
{
    public class DeleteTraineeAssessmentMarkCommandHandler : IRequestHandler<DeleteTraineeAssessmentMarkCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTraineeAssessmentMarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTraineeAssessmentMarkCommand request, CancellationToken cancellationToken)
        {
            var TraineeAssessmentMarks = await _unitOfWork.Repository<TraineeAssessmentMark>().Get(request.TraineeAssessmentMarkId);

            if (TraineeAssessmentMarks == null)
                throw new NotFoundException(nameof(TraineeAssessmentMark), request.TraineeAssessmentMarkId);

            await _unitOfWork.Repository<TraineeAssessmentMark>().Delete(TraineeAssessmentMarks);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
