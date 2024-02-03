using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Handlers.Commands
{
    public class DeleteTraineeAssissmentGroupCommandHandler : IRequestHandler<DeleteTraineeAssissmentGroupCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTraineeAssissmentGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTraineeAssissmentGroupCommand request, CancellationToken cancellationToken)
        {
            var TraineeAssissmentGroups = await _unitOfWork.Repository<TraineeAssissmentGroup>().Get(request.TraineeAssissmentGroupId);

            if (TraineeAssissmentGroups == null)
                throw new NotFoundException(nameof(TraineeAssissmentGroup), request.TraineeAssissmentGroupId);

            await _unitOfWork.Repository<TraineeAssissmentGroup>().Delete(TraineeAssissmentGroups);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
