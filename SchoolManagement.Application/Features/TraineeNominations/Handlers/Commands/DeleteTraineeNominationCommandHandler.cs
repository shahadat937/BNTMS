using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Commands
{
    public class DeleteTraineeNominationCommandHandler : IRequestHandler<DeleteTraineeNominationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTraineeNominationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTraineeNominationCommand request, CancellationToken cancellationToken)
        {
            var TraineeNominations = await _unitOfWork.Repository<TraineeNomination>().Get(request.TraineeNominationId);

            if (TraineeNominations == null)
                throw new NotFoundException(nameof(TraineeNomination), request.TraineeNominationId);

            var traineeBiodata = await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Get(TraineeNominations.TraineeId ?? 0);
            traineeBiodata.LocalNominationStatus = 0;

            await _unitOfWork.Repository<TraineeBioDataGeneralInfo>().Update(traineeBiodata);

            await _unitOfWork.Repository<TraineeNomination>().Delete(TraineeNominations);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
