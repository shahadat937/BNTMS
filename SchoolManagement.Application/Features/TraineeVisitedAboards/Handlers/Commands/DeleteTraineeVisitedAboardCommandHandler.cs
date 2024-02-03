using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeVisitedAboards.Handlers.Commands
{
    public class DeleteTraineeVisitedAboardCommandHandler : IRequestHandler<DeleteTraineeVisitedAboardCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTraineeVisitedAboardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTraineeVisitedAboardCommand request, CancellationToken cancellationToken)
        {
            var TraineeVisitedAboards = await _unitOfWork.Repository<TraineeVisitedAboard>().Get(request.TraineeVisitedAboardId);

            if (TraineeVisitedAboards == null)
                throw new NotFoundException(nameof(TraineeVisitedAboard), request.TraineeVisitedAboardId);

            await _unitOfWork.Repository<TraineeVisitedAboard>().Delete(TraineeVisitedAboards);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
