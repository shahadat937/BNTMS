using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Handlers.Commands
{
    public class DeleteTrainingSyllabusCommandHandler : IRequestHandler<DeleteTrainingSyllabusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTrainingSyllabusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTrainingSyllabusCommand request, CancellationToken cancellationToken)
        {
            var TrainingSyllabus = await _unitOfWork.Repository<TrainingSyllabus>().Get(request.TrainingSyllabusId);

            if (TrainingSyllabus == null)
                throw new NotFoundException(nameof(TrainingSyllabus), request.TrainingSyllabusId);

            await _unitOfWork.Repository<TrainingSyllabus>().Delete(TrainingSyllabus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
