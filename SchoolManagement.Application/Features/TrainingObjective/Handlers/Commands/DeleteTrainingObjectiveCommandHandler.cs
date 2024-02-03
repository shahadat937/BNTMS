using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TrainingObjectives.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TrainingObjectives.Handlers.Commands
{
    public class DeleteTrainingObjectiveCommandHandler : IRequestHandler<DeleteTrainingObjectiveCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTrainingObjectiveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTrainingObjectiveCommand request, CancellationToken cancellationToken)
        {
            var TrainingObjective = await _unitOfWork.Repository<TrainingObjective>().Get(request.TrainingObjectiveId);

            if (TrainingObjective == null)
                throw new NotFoundException(nameof(TrainingObjective), request.TrainingObjectiveId);

            await _unitOfWork.Repository<TrainingObjective>().Delete(TrainingObjective);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
